using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.Reports.Resources;

namespace FNSB.Publicworks.Projects.Reports.UI
{
    public partial class Contractor : Form
    {
        private readonly publicworksEntities _db;
        private Int32 _id;
        private String _contractor;

        public Contractor()
        {
            _db = new publicworksEntities();
            InitializeComponent();
        }

        private void EntityFormLoad(object sender, EventArgs e)
        {
            try
            {
                SetUpCombobox();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EntityComboSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (entitySelect.SelectedValue != null)
                {
                    _id = (int)entitySelect.SelectedValue;

                    //use EF db object to query for the arceng record
                    var type = _db.Contractors.Find(_id);

                    if (type == null)
                    {
                        Clean();
                        throw new Exception("ProjectContactorComboSelected method recieved error from db.Find(Id) routine");   //SelectedValue has ID that cannot be found in context
                    }
                    //variables
                    _id = type.ppn_recordid;
                    _contractor = type.contractorname;
                    //controls
                    ContractorName.Text = _contractor;
                    //form state
                    ValueSelectedSetupForm();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }


        private void SaveClick(object sender, EventArgs e)
        {
            //user selected save - check for id to determine add or modify
            if (_id == 0)
            {
                try
                {
                    int foo = EntityAdd();   //add values in textboxes to db
                    if (foo == -1)
                        throw new Exception("Save method recieved error from EntityAdd routine");
                    if (foo == 1)
                        Clean();
                    if (foo > 1)
                        SetUpCombobox();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
            else
                try
                {
                    int foo = EntityUpdate(_id);    //update values on textboxes based on selected val in combobox
                    SetUpCombobox();
                    if (foo == -1)
                        throw new Exception("Save method recieved error from EntityUpdate routine");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
        }


        private void SetUpCombobox()
        {
            //parent query to get all the architects into an ordered 
            var dictionary = _db.Contractors.ToDictionary(c => c.ppn_recordid, c => c.contractorname).OrderBy(a => a.Value);
            entitySelect.ValueMember = "Key";
            entitySelect.DisplayMember = "Value";
            entitySelect.DataSource = dictionary.ToList();
        }


        private void SetupNewEntity(object sender, EventArgs e)
        {
            Clean();
        }

        private void ClearEntityClick(object sender, EventArgs e)
        {
            Clean();
        }

        private int EntityAdd()
        {
            if (_id != 0) return -1;
            var contractor = new DataLayer.Model.Contractor();
            {
                contractor.contractorname = this.ContractorName.Text.Trim(); //add value
            };
            //check for existing duplicate Contractor
            var list = _db.Contractors.Where(m => contractor.contractorname == m.contractorname).ToList();
            if (list.Count == 0)
            {
                var myitem = _db.Contractors.Add(contractor);
                int saveChanges = _db.SaveChanges();
                return saveChanges; //return number of changes made to the database since last SaveChanges
            }

            MessageBox.Show(
                MessageStrings.SaveAddMatchingRecordFound,
                MessageStrings.ContractorDialogHeader,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return 0;

        }

        private int EntityUpdate(int recordid)
        {
            //exit routine if recordid is missing
            if (recordid == 0) return -1;

            var entity = _db.Contractors.Find(recordid);    //fetch the record to update
            entity.contractorname = ContractorName.Text.Trim();   //update value
            _db.Entry(entity).State = EntityState.Modified;  //witchcraft to tell DB to update POCO recordid
            int j = _db.SaveChanges();  //issue save to context

            return j;       //return number of changes made to the database since last SaveChanges
        }

        private void EntityDelete(Int32 id)
        {
            //Delete and save - Cascade set to replace ppa_record in Rpojects table with default key for Unassigned
            var entity = _db.Contractors.Find(id);
            _db.Entry(entity).State = EntityState.Deleted;
            int k = _db.SaveChanges();
        }

        private void ValueSelectedSetupForm()
        {
            entityExit.Enabled = true;
            clearEntity.Enabled = true;
            newEntity.Enabled = true;
            deleteEntity.Enabled = true;
            saveEntity.Enabled = false;
        }

        private void Clean()
        {
            //var state
            _id = 0;
            _contractor = String.Empty;
            //combo / text state
            entitySelect.SelectedIndex = -1;
            ContractorName.Text = String.Empty;
            //cmd state
            entityExit.Enabled = true;
            clearEntity.Enabled = false;
            saveEntity.Enabled = false;
            deleteEntity.Enabled = false;
            newEntity.Enabled = false;
            ContractorName.Focus();
        }

        private void FirstNameTextChanged(object sender, EventArgs e)
        {
            string type = ContractorName.Text.Trim();

            //if (firstname == String.Empty) return;
            if (_contractor != type)
            {
                saveEntity.Enabled = true;
            }
            else if (_contractor == type)
            {
                saveEntity.Enabled = false;
            }
        }

        private void DeleteEntityClick(object sender, EventArgs e)
        {
            if (_id > 0)
            {
                if (EntityProjectCount(_id) > 0)
                {
                    //TODO Script the default recordid to Unassigned when updating databases
                    DialogResult result = MessageBox.Show(MessageStrings.ContractorDeleteConfirmWithProjectsMsg,
                                                          MessageStrings.ContractorDialogHeader, MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Cancel) return;
                }
                else if (EntityProjectCount(_id) == 0)
                {
                    DialogResult result = MessageBox.Show(MessageStrings.ContractorDeleteConfirmMessage,
                                   MessageStrings.ContractorDialogHeader, MessageBoxButtons.OKCancel,
                                  MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Cancel) return;
                }

                //Delete method call and save
                EntityDelete(_id);
                SetUpCombobox();

            }
        }

        private Int32 EntityProjectCount(int id)
        {
            try
            {
                if (id == 0)
                    return -1;

                int count = _db.Contractors.Find(id).Projects.Count();
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void ExitEntity(object sender, EventArgs e)
        {
            try
            {
                //Entity loaded - look at text control to compare and if changed ask to modify
                if (_id > 0)
                {
                    if (_contractor != ContractorName.Text.Trim())
                    {

                        DialogResult result = MessageBox.Show(MessageStrings.SaveModifiedBeforeExit,
                                                               MessageStrings.ContractorDialogHeader, MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            int foo = EntityUpdate(_id);
                        }
                    }
                    this.Close();
                }
                //Entity not loaded - look at text control for adds
                else if (_id == 0)
                {
                    if (ContractorName.Text.Trim() != String.Empty)
                    {
                        DialogResult result = MessageBox.Show(MessageStrings.SaveNewBeforeExit,
                                                               MessageStrings.ContractorDialogHeader, MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Exclamation);

                        if (result == DialogResult.Yes)
                        {
                            int foo = EntityAdd();
                        }
                    }
                    this.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
