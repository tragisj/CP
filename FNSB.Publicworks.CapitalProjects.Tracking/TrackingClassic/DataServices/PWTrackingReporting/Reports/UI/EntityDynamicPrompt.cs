using System;
using System.Collections;
using System.Windows.Forms;

namespace FNSB.Publicworks.Projects.Reporting.Reports.UI
{
    public partial class EntityDynamicPrompt : Form
    {

        public int EntityId { get; set; }
        public string FormTitle { get; set; }
        public string SelectBoxLabel { get; set; }
        public bool SelectionCancel { get; set; }
        public IList EntitySelectDataSourceDictionary    { get; set; }
        private Int32 _id;

        public EntityDynamicPrompt()
        {
            InitializeComponent();
        }

        private void EntityComboSelectLoad(object sender, EventArgs e)
        {
            SetUpCombobox();
        }

        private void EntityComboSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (entitySelect.SelectedValue == null) return;
                if (allRadio.Checked) uniqueRadio.Checked = true;
 
                _id = (int) entitySelect.SelectedValue;
                uniqueRadio.Checked = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void SetUpCombobox()
        {
            var list = EntitySelectDataSourceDictionary;
            entitySelect.ValueMember = "Key";
            entitySelect.DisplayMember = "Value";
            entitySelect.DataSource = list;
        }


        private void EntityCheckChange(object sender, EventArgs e)
        {
            if (allRadio.Checked)
            {
                _id = 0;
                entitySelect.SelectedIndex = -1;
            }
            else if (!allRadio.Checked)
            {
                
            }
        }

        private void SubmitClick(object sender, EventArgs e)
        {
            EntityId = _id;
            this.DialogResult = DialogResult.OK;
        }

        private void CancelClick(object sender, EventArgs e)
        {
            SelectionCancel = true;
            Close();
        }

    }
}










