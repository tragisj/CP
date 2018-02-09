using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FNSB.Publicworks.Projects.DataLayer.Service;
using FNSB.Publicworks.Projects.Reports.Resources;

namespace FNSB.Publicworks.Projects.Reports.UI
{
    public partial class ImportAcceptionManager : Form
    {
        private GlkeyImportManager manager;
        Dictionary<string, string> _keyDictionary =  new Dictionary<string, string>();

        private string _key;
        private string _desc;

        #region LoadEvents

        public ImportAcceptionManager()
        {
            InitializeComponent();
            GetAcceptionsFromFile();
        }


        /// <summary>
        /// populates the listbox with the acception data from the dictionary of gkley acceptions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportAcceptionManagerLoad(object sender, EventArgs e)
        {
            GenerateListBoxValues();
            acceptionsListBox.ItemSelectionChanged += AcceptionsListBoxItemSelectionChanged;

        }

        private void GenerateListBoxValues()
        {
            
            acceptionsListBox.Clear();
            acceptionsListBox.Columns.Add("Key", "Block Key", 50, HorizontalAlignment.Right, "");
            acceptionsListBox.Columns.Add("Value", "Reason", 250, HorizontalAlignment.Left, "");

            foreach (var key in _keyDictionary)
            {
                acceptionsListBox.Items.Add(new ListViewItem(new string[] { key.Key, key.Value }));
            }
            
        }

        /// <summary>
        /// Created GlkeyImportManager object and copies the key/value dictionary to local dictionary
        /// </summary>
        private void GetAcceptionsFromFile()
        {
            manager = new GlkeyImportManager(Resources.FilePaths.GlkeyAcceptionsFile);
            if (!manager.AcceptionsDictionary.Any()) return;
            _keyDictionary = manager.AcceptionsDictionary.ToDictionary(p => p.Key, p => p.Value);
        }

        #endregion

        /// <summary>
        /// captures the selected values from the item selected from the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcceptionsListBoxItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //parse the selection into fields
            _key = e.Item.Text;
            _desc = e.Item.SubItems[1].Text;

            //display to user
            glkeyText.Text = _key;
            descText.Text = _desc;

            deleteCommand.Enabled = true;
            saveCommand.Enabled = true;
            
        }


        /// <summary>
        /// new acception command resets the form to add mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCommandClick(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void SaveCommandClick(object sender, EventArgs e)
        {
            //checks the key for duplication
            if (_keyDictionary.ContainsKey(_key))
            {
                manager.ModifyAcception(_key, _desc);
                _keyDictionary[_key] = _desc;
            }
            else
            {
                manager.AddAcception(_key, _desc);
                _keyDictionary.Add(_key, _desc);
            }

            GenerateListBoxValues();
            ClearForm();
        }

        private void ClearForm()
        {

            _key = string.Empty;
            _desc = string.Empty;
            glkeyText.Text = string.Empty;
            descText.Text = string.Empty;

            glkeyText.Focus();
            saveCommand.Enabled = false;
            deleteCommand.Enabled = false;
            acceptionsListBox.Refresh();

        }

        private void DeleteCommandClick(object sender, EventArgs e)
        {
            var dialog =
                MessageBox.Show(MessageStrings.GlkeyAcceptionsVerifiyDelete, "Public Works", MessageBoxButtons.OKCancel);
            if (dialog == DialogResult.Cancel) return;

            manager.RemoveAcception(_key);
            _keyDictionary.Remove(_key);
            GenerateListBoxValues();
            ClearForm();
            
        }

        private void ExitCommandClick(object sender, EventArgs e)
        {
            Close();
        }

        private void GlkeyTextKeyUp(object sender, KeyEventArgs e)
        {
            _key = glkeyText.Text;
            saveCommand.Enabled = true;
        }

        private void DescTextKeyUp(object sender, KeyEventArgs e)
        {
            _desc = descText.Text;
        }
    }
}
