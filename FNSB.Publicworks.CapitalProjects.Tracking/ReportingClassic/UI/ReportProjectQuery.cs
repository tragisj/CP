using System;
using System.Linq;
using System.Windows.Forms;
using GrapeCity.ActiveReports;

namespace PWTrackingReporting.UI
{
    public partial class ReportProjectQuery : Form
    {
        //Report selected on the ReportListing UI form
        public SectionReport ReportInProcess { get; set; }
        //public Enum QueryType


        public ReportProjectQuery()
        {
            InitializeComponent();
        }

        //HACK not dynamic here. The user may be running a secretary report. Need method to setup the query form based on users initial report sepection.
        //maybe a enum for manger, secretary, users, architects, projects, funds then the grid is loaded per type
        //private void ReportProjectQueryLoad(object sender, System.EventArgs e)
        //{
        //    //Projects Repository call to get the active projects in IEnumerable form
        //    var projects = new ProjectsRepository();
        //    var projectMgrs = projects.GetProjects();   //retrieves the projects

        //    ////projectMgr LINQ query to a list of projects for ProjectManagers with project assigned
        //    //var projectMgr = from p in projectMgrs where p.ProjectManager.Projects.Count != 0 orderby p.ProjectManager.ppr_recordid
        //    //                 select new Domain.Projects
        //    //                            {
        //    //                                ProjectManager = String.Format("{0} {1}", p.ProjectManager.firstname, p.ProjectManager.lastname),
        //    //                                ProjectNumber = p.PPM_Project_Number,
        //    //                                ProjectName = p.PPM_Project_Name,
        //    //                                ProjectId = p.PPM_Recordid
        //    //                            };

        //    ////plug the LINQ query into the datagrid
        //    //queryDataGrid.DataSource = projectMgr.ToList();

        //    //DataColumn is placed into object for management
        //    C1DataColumn dc = queryDataGrid.Columns["ProjectManager"];
        //    queryDataGrid.GroupedColumns.Add(dc);

        //    //Display column is taken to manage the view state of the projectid column
        //    var vd = queryDataGrid.Splits[0].DisplayColumns["ProjectId"];
        //    vd.Visible = false; //projectid make invisible
        //}

        //private void CmdRunClick(object sender, EventArgs e)
        //{
        //    if (ReportInProcess == null) return;
        //    ReportInProcess.DataSource = queryDataGrid.DataSource;

        //    ReportInProcess.Run();
        //    var viewer = new ActiveReportViewer(ReportInProcess) {MdiParent = this.MdiParent};
        //    viewer.Show();
        //}
    }
}
