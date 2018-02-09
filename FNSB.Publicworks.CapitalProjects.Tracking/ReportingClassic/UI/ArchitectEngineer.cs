using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FNSB.Publicworks.Projects.DataLayer.Model;
using FNSB.Publicworks.Projects.Reports.Resources;

namespace FNSB.Publicworks.Projects.Reports.UI
{
    public partial class ArchitectEngineer : Form
    {
        private publicworksEntities _db;
        private Int32 _architectId;
        private String _architectFirst;
        private String _architectLast;

        public ArchitectEngineer()
        {
            _db = new publicworksEntities();
            InitializeComponent();
        }

        private void ArchitectManagerLoad(object sender, EventArgs e)
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

        private void ArchitectComboSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (architectCombo.SelectedValue != null)
                {
                    _architectId = (int) architectCombo.SelectedValue;

                    //use EF db object to query for the arceng record
                    DataLayer.Model.ArchitectEngineer architect = _db.ArchitectEngineers.Find(_architectId);
                    
                    if (architect == null)
                    {
                        CleanArchitectForm();
                        throw new Exception("ArchitectComboSelected method recieved error from db.Find(Id) routine");   //SelectedValue has ID that cannot be found in context
                    }
                    else
                    {
                        //variables
                        _architectId = architect.recordid;
                        _architectFirst = architect.firstname; 
                        _architectLast = architect.lastname;
                        //controls
                        architectFirst.Text = _architectFirst;  
                        architectLast.Text = _architectLast;
                        //form state
                        ValueSelectedArchitectForm();   
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }


        private void SaveArchitectClick(object sender, EventArgs e)
        {
            //user selected save - check for id to determine add or modify
            if (_architectId == 0)
            {
                try
                {
                    int foo = ArchitectAdd();   //add values in textboxes to db
                    if (foo == -1)
                        throw new Exception("Save method recieved error from EntityAdd routine");
                    if (foo == 0)
                        CleanArchitectForm();
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
                    int foo = ArchitectUpdate(_architectId);    //update values on textboxes based on selected val in combobox
                    SetUpCombobox();
                    if (foo == -1)
                        throw new Exception("SaveArchitect method recieved error from ArchitectUpdate routine");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
           }


        private void SetUpCombobox()
        {
            //parent query to get all the architects into an ordered 
            var architects = _db.ArchitectEngineers.ToDictionary(c => c.recordid, c => c.firstname + " " + c.lastname).OrderBy(e => e.Value);
            architectCombo.ValueMember = "Key";
            architectCombo.DisplayMember = "Value";
            architectCombo.DataSource = architects.ToList();
        }


        private void SetupNewArchitect(object sender, EventArgs e)
        {
            CleanArchitectForm();
        }

        private void ClearArchitectClick(object sender, EventArgs e)
        {
            CleanArchitectForm();
        }

        private int ArchitectAdd()
        {
            //_db.ArchitectEngineers
            if (_architectId != 0) return -1;
            var architect = new DataLayer.Model.ArchitectEngineer()
                                              {
                                                  firstname = architectFirst.Text.Trim(),   //add value
                                                  lastname = architectLast.Text.Trim()
                                              };

            //check for matching values in the table so duplicates are not created
            var list = _db.ArchitectEngineers.Where(m => m.firstname == architect.firstname && m.lastname == architect.lastname).ToList();
            if (list.Count == 0)    //no duplicates so add record
            {
                var myitem = _db.ArchitectEngineers.Add(architect);
                int saveChanges = _db.SaveChanges();
                return saveChanges; //return number of changes made to the database since last SaveChanges
            }

            MessageBox.Show(
                MessageStrings.SaveAddMatchingRecordFound,
                MessageStrings.UserDialogHeader,
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            return 0;           
        }


        private int ArchitectUpdate(int recordid)
        {
            //exit routine if recordid is missing
            if (recordid == 0) return -1;

            var architect = _db.ArchitectEngineers.Find(recordid);    //fetch the record to update
            architect.firstname = architectFirst.Text.Trim();   //update value
            architect.lastname = architectLast.Text.Trim();
            _db.Entry(architect).State = EntityState.Modified;  //witchcraft to tell DB to update POCO recordid
            int j = _db.SaveChanges();  //issue save to context

            return j;       //return number of changes made to the database since last SaveChanges
        }

       
        private void ArchitectDelete(Int32 architectid)
        {
            //Delete and save - Cascade set to replace ppa_record in Rpojects table with default key for Unassigned
            var delarc = _db.ArchitectEngineers.Find(architectid);
            _db.Entry(delarc).State = EntityState.Deleted;
            int k = _db.SaveChanges();

        }

        private void ValueSelectedArchitectForm()
        {
            exitArchitect.Enabled = true;
            clearArchitect.Enabled = true;
            newArchitect.Enabled = true;
            deleteArchitect.Enabled = true;

            saveArchitect.Enabled = false;
        }

        private void CleanArchitectForm()
        {
            //var state
            _architectId = 0;
            _architectFirst = String.Empty;
            _architectLast = String.Empty;
            //combo / text state
            architectCombo.SelectedIndex = -1;  
            architectFirst.Text = String.Empty;
            architectLast.Text = String.Empty;
            //cmd state
            exitArchitect.Enabled = true;   
            clearArchitect.Enabled = false;
            saveArchitect.Enabled = false;
            deleteArchitect.Enabled = false;
            newArchitect.Enabled = false;

            architectFirst.Focus();
        }

        private void ArchitectFirstTextChanged(object sender, EventArgs e)
        {
           string firstname = architectFirst.Text.Trim();

           //if (firstname == String.Empty) return;
            if (_architectFirst != firstname)
            {
                saveArchitect.Enabled = true;
            }
            else if (_architectFirst == firstname)
            {
                saveArchitect.Enabled = false;
            }
        }

        private void ArchitectLastTextChanged(object sender, EventArgs e)
        {
            string lastname = architectLast.Text.Trim();

            //if (lastname == String.Empty) return;
            if (_architectLast != lastname)
            {
                saveArchitect.Enabled = true;
            }
            else if (_architectLast == lastname)
            {
                saveArchitect.Enabled = false;
            }
        }

        private void DeleteArchitectClick(object sender, EventArgs e)
        {
                if (_architectId > 0)
                {
                    if (ArchitectProjectCount(_architectId) > 0)
                    {


                        DialogResult result = MessageBox.Show(MessageStrings.ArchitectDeleteConfirmWithProjectsMsg,
                                                              MessageStrings.ArchitectDialogHeader, MessageBoxButtons.OKCancel,
                                                              MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Cancel) return;
                    }
                    else if (ArchitectProjectCount(_architectId) == 0)
                    {
                        DialogResult result = MessageBox.Show(MessageStrings.ArchitectDeleteConfirmMessage,
                                      MessageStrings.ArchitectDialogHeader, MessageBoxButtons.OKCancel,
                                      MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Cancel) return;
                    }

                    //Delete method call and save
                    ArchitectDelete(_architectId);
                    SetUpCombobox();
                 
                }
        }

        private Int32 ArchitectProjectCount(int architectId)
        {
            try
            {
                if (architectId == 0)
                    return -1;

                int count = _db.ArchitectEngineers.Find(architectId).Projects.Count();
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        private void ExitArchitect(object sender, EventArgs e)
        {
            try
            {
                //Architect loaded - look at text control to compare and if changed ask to modify
                if (_architectId > 0)
                {
                    if (_architectFirst != architectFirst.Text.Trim() || _architectLast != architectLast.Text.Trim())
                    {
                        DialogResult result = MessageBox.Show(MessageStrings.SaveModifiedBeforeExit,
                                                             MessageStrings.ArchitectDialogHeader, MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                        {
                            int foo = ArchitectUpdate(_architectId);
                        }
                    }
                    this.Close();
                }
                //Architect not loaded - look at text control for adds
                else if (_architectId == 0)
                {
                    if (architectFirst.Text.Trim() != String.Empty || architectLast.Text.Trim() != String.Empty)
                    {
                        DialogResult result = MessageBox.Show(MessageStrings.SaveNewBeforeExit,
                                                              MessageStrings.ArchitectDialogHeader, MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Exclamation);

                        if (result == DialogResult.Yes)
                        {
                            int foo = ArchitectAdd();
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
