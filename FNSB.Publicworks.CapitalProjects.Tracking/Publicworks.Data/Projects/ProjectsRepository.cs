using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Data.Context;
using Publicworks.Entities.Admin;
using Publicworks.Entities.Projects;
using Publicworks.Entities.Projects.ViewModels;
using Publicworks.Entities.Projects.ViewModels.Admin;

namespace Publicworks.Data.Projects
{
    public class ProjectsRepository
    {

        public List<ProjectViewModel> GetProjects()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Project> projects = new List<Project>();
                projects = context.Projects.AsNoTracking().ToList();

                if (projects != null)
                {
                    List<ProjectViewModel> projectsDisplay = new List<ProjectViewModel>();

                    foreach (var x in projects)
                    {
                        var projectDisplay = new ProjectViewModel()
                        {
                            ProjectID = x.ProjectID,
                            ProjectName = x.ProjectName,
                            ProjectNumber = x.ProjectNumber,
                            ActiveProject = x.ActiveProject,
                            StatusDescription = x.StatusDescription,
                            ProjectScope = x.ProjectScope,
                            BidOpening = x.BidDate,
                            ActiveDate = x.Activated
                        };

                        projectsDisplay.Add(projectDisplay);
                    }
                    return projectsDisplay;
                }
            }
            return null;
        }


        public object GetProject(Guid projectId)
        {
            if (projectId != Guid.Empty)
            {
                using (var context = new ApplicationDbContext())
                {
                    var Project = context.Projects.AsNoTracking()
                        .Where(x => x.ProjectID == projectId)
                        .SingleOrDefault();

                    if (Project != null)
                    {
                        var projectEditVm = new ProjectViewModel()
                        {
                            ProjectName = Project.ProjectName.Trim(),
                            ProjectNumber = Project.ProjectNumber.Trim(),
                            ActiveProject = Project.ActiveProject,
                            StatusDescription = Project.StatusDescription.Trim(),
                            ProjectManager = $"{Project.ProjectManager.FirstName} {Project.ProjectManager.LastName}",
                            ArchitectEngineer = $"{Project.ArchitectEngineer.FirstName} {Project.ArchitectEngineer.LastName}",
                            Secretary = $"{Project.Secretary.FirstName} {Project.Secretary.LastName}",
                            ProjectUser = $"{Project.ProjectUser.FirstName} {Project.ProjectUser.LastName}",
                            Consultant = $"{Project.Consultant.ConsultantName}",
                            ConsultantDesc = Project.Consultant.Description,
                            Contractor = $"{Project.Contractor.ContractorName}",
                            ProjectType = Project.ProjectType.Name,
                            ActiveDate = Project.Activated,
                            BidOpening = Project.BidDate,
                            ProjectScope = Project.ProjectScope,
                            AgendaSetting = Project.AgendaSetting,
                            BidOpening = Project.BidOpening,
                            ConstructionBidAward = Project.ConstructionBidAward,
                            DesignCompleted = Project.DesignCompleted,
                            OriginalBidDate = Project.OriginalBidDate,
                            PercentDesignComplete = Project.PercentDesignComplete
                        };

                        return projectEditVm;
                    }
                }
            }
            return null;
        }





        public bool UpdateProject(ProjectUserEditViewModel model)
        {
            throw new NotImplementedException();
        }





    }
}
