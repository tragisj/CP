using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using FNSB.Publicworks.Projects.DataLayer.Model;

namespace FNSB.Publicworks.Projects.Reporting.UI
{
    public partial class ProjectTracking : Form
    {
        private publicworksEntities _ctx = new publicworksEntities();
        private BindingSource _projectsBind = new BindingSource();
        private BindingSource _fundBind = new BindingSource();


        public ProjectTracking()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                _ctx = new publicworksEntities();
                _ctx.Projects.Load();
                _ctx.ArchitectEngineers.Load();

                projectBindingSource.DataSource =
                 _ctx.Projects.Local.ToBindingList().Where(p => p.PPM_Project_Active == true);

                // projectGrid.AllowSort = true;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void projectDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var i = e.RowIndex;
        }


    }
}
