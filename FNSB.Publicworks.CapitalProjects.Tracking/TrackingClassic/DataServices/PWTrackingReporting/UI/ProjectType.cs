using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.Reports.Resources;

namespace FNSB.Publicworks.Projects.Reports.UI
{
    public partial class ProjectType : Form
    {
        private readonly publicworksEntities _db;
        private Int32 _id;
        private String _category;

        public ProjectType()
        {
            _db = new publicworksEntities();
            InitializeComponent();
        }

        private void EntityFormLoad(object sender, EventArgs e)
        {
            try
            {
                SetUpCombobox();  //Loads the combo with project type as datasource and uses Id to set value if valid - else index -1
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
                    DataLayer.Model.ProjectType type = _db.ProjectTypes.Find(_id);

                    if (type == null)
                    {
                        Clean();
                        throw new Exception("ProjectTypesComboSelected method recieved error from db.Find(Id) routine");   //SelectedValue has ID that cannot be found in context
                    }
                    //variables
                    _id = type.ppt_recordid;
                    _category = type.category;
                    //controls
                    TypeCategory.Text = _category;
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
                        throw new Exception("Save me    thod recieved error from EntityAdd routine");
                    if (foo == 0)
                        Clean();    //reset the from
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
                 
                    if (foo == -1)
                        throw new Exception("Save method recieved error from EntityUpdate routine");
                    SetUpCombobox();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
        }


        private void SetUpCombobox()
        {
            //parent query to get all the architects into an ordered 
            var dictionary = _db.ProjectTypes.ToDictionary(c => c.ppt_recordid, c => c.category).OrderBy(a => a.Value);
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
            var type = new DataLayer.Model.ProjectType()
            {
                category = this.TypeCategory.Text.Trim(),   //add value
            };

            //check for the existing project types
            var list = _db.ProjectTypes.Where(m => m.category == type.category).ToList();
            if (list.Count == 0)
            {
                var myitem = _db.ProjectTypes.Add(type);
                int saveChanges = _db.SaveChanges();
                return saveChanges; //return number of changes made to the database since last SaveChanges
            }

            MessageBox.Show(
                MessageStrings.SaveAddMatchingRecordFound,
                MessageStrings.TypesDialogHeader,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);


            return 0;
        }

        private int EntityUpdate(int recordid)
        {
            //exit routine if recordid is missing
            if (recordid == 0) return -1;

            var entity = _db.ProjectTypes.Find(recordid);    //fetch the record to update
            entity.category = TypeCategory.Text.Trim();   //update value
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
            _category = String.Empty;
            //combo / text state
            entitySelect.SelectedIndex = -1;
            TypeCategory.Text = String.Empty;
            //cmd state
            exitEntity.Enabled = true;
            clearEntity.Enabled = false;
            saveEntity.Enabled = false;
            deleteEntity.Enabled = false;
            newEntity.Enabled = false;
            TypeCategory.Focus();
        }

        private void FirstNameTextChanged(object sender, EventArgs e)
        {
            string type = TypeCategory.Text.Trim();

            //if (firstname == String.Empty) return;
            if (_category != type)
            {
                saveEntity.Enabled = true;
            }
            else if (_category == type)
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
                    DialogResult result = MessageBox.Show(MessageStrings.TypesDeleteConfirmWithProjectsMsg,
                                                          MessageStrings.TypesDialogHeader, MessageBoxButtons.OKCancel,
                                                          MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Cancel) return;
                }
                else if (EntityProjectCount(_id) == 0)
                {
                    DialogResult result = MessageBox.Show(MessageStrings.TypesDeleteConfirmMessage,
                                   MessageStrings.TypesDialogHeader, MessageBoxButtons.OKCancel,
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
                    if (_category != TypeCategory.Text.Trim())
                    {

                        DialogResult result = MessageBox.Show(MessageStrings.SaveModifiedBeforeExit,
                                                               MessageStrings.TypesDialogHeader, MessageBoxButtons.YesNo,
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
                    if (TypeCategory.Text.Trim() != String.Empty)
                    {
                        DialogResult result = MessageBox.Show(MessageStrings.SaveNewBeforeExit,
                                                               MessageStrings.TypesDialogHeader, MessageBoxButtons.YesNo,
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
