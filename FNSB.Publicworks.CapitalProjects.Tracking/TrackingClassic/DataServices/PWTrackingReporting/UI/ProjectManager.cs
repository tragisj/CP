using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.Reports.Resources;

namespace FNSB.Publicworks.Projects.Reports.UI
{
    public partial class ProjectManager : Form
    {
        private readonly publicworksEntities _db;
        private Int32 _id;
        private String _first;
        private String _last;
        //private ResourceManager _resource = new ResourceManager(typeof(ProjectManager));

        public ProjectManager()
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
                    DataLayer.Model.ProjectManager manager = _db.ProjectManagers.Find(_id);
                    
                    if (manager == null)
                    {
                        Clean();
                        throw new Exception("ProjectManagerComboSelected method recieved error from db.Find(Id) routine");   //SelectedValue has ID that cannot be found in context
                    }
                    //variables
                    _id = manager.ppr_recordid;
                    _first = manager.firstname;
                    _last = manager.lastname;
                    //controls
                    firstName.Text = _first;
                    lastName.Text = _last;
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
                    if (foo == 0)
                        Clean();
                    if (foo > 0)
                        SetUpCombobox();    //reinit the combobox

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
            var dictionary = _db.ProjectManagers.ToDictionary(c => c.ppr_recordid, c => c.firstname + " " + c.lastname).OrderBy(a => a.Value);
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
            var manager = new DataLayer.Model.ProjectManager()
                              {
                                  firstname = firstName.Text.Trim(),
                                  //add value
                                  lastname = lastName.Text.Trim()
                              };

            //check for the 
            var managercheck =_db.ProjectManagers.Where(m => m.firstname == manager.firstname && m.lastname == manager.lastname).ToList();
            if (managercheck.Count == 0)
            {
                var myitem = _db.ProjectManagers.Add(manager);
                int i = _db.SaveChanges();
                return i;   //return number of changes made to the database since last SaveChanges
            }

                MessageBox.Show(MessageStrings.SaveAddMatchingRecordFound, MessageStrings.UserDialogHeader,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

            return 0;
        }

        private int EntityUpdate(int recordid)
        {
            //exit routine if recordid is missing
            if (recordid == 0) return -1;

            var entity = _db.ProjectManagers.Find(recordid);    //fetch the record to update
            entity.firstname = firstName.Text.Trim();   //update value
            entity.lastname = lastName.Text.Trim();
            _db.Entry(entity).State = EntityState.Modified;  //witchcraft to tell DB to update POCO recordid
            int j = _db.SaveChanges();  //issue save to context
            return j;       //return number of changes made to the database since last SaveChanges
        }

        private void EntityDelete(Int32 id)
        {
            //Delete and save - Cascade set to replace ppa_record in Rpojects table with default key for Unassigned
            var entity = _db.ProjectManagers.Find(id);
            _db.Entry(entity).State = EntityState.Deleted;
            int k = _db.SaveChanges();
        }

        private void ValueSelectedSetupForm()
        {
            exitEntity.Enabled = true;
            clearEntity.Enabled = true;
            newEntity.Enabled = true;
            deleteEntity.Enabled = true;
            saveEntity.Enabled = false;
        }

        private void Clean()
        {
            //var state
            _id = 0;
            _first = String.Empty;
            _last = String.Empty;
            //combo / text state
            entitySelect.SelectedIndex = -1;
            firstName.Text = String.Empty;
            lastName.Text = String.Empty;
            //cmd state
            exitEntity.Enabled = true;
            clearEntity.Enabled = false;
            saveEntity.Enabled = false;
            deleteEntity.Enabled = false;
            newEntity.Enabled = false;
            firstName.Focus();
        }

        private void FirstNameTextChanged(object sender, EventArgs e)
        {
            string firstname = firstName.Text.Trim();

            //if (firstname == String.Empty) return;
            if (_first != firstname)
            {
                saveEntity.Enabled = true;
            }
            else if (_first == firstname)
            {
                saveEntity.Enabled = false;
            }
        }

        private void LastNameTextChanged(object sender, EventArgs e)
        {
            string lastname = lastName.Text.Trim();

            //if (lastname == String.Empty) return;
            if (_last != lastname)
            {
                saveEntity.Enabled = true;
            }
            else if (_last == lastname)
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
                    DialogResult result = MessageBox.Show(MessageStrings.ManagerDeleteConfirmWithProjectsMsg,
                                                          MessageStrings.ManagerDialogHeader, MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Cancel) return;
                }
                else if (EntityProjectCount(_id) == 0)
                {
                    DialogResult result = MessageBox.Show(MessageStrings.ManagerDeleteConfirmMessage,
                                   MessageStrings.ManagerDialogHeader, MessageBoxButtons.OKCancel,
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

                int count = _db.ProjectManagers.Find(id).Projects.Count();
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
                    if (_first != firstName.Text.Trim() || _last != lastName.Text.Trim())
                    {

                        DialogResult result = MessageBox.Show(MessageStrings.SaveModifiedBeforeExit,
                                                               MessageStrings.ManagerDialogHeader, MessageBoxButtons.YesNo,
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
                    if (firstName.Text.Trim() != String.Empty || lastName.Text.Trim() != String.Empty)
                    {
                        DialogResult result = MessageBox.Show(MessageStrings.SaveNewBeforeExit,
                                                               MessageStrings.ManagerDialogHeader, MessageBoxButtons.YesNo,
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
