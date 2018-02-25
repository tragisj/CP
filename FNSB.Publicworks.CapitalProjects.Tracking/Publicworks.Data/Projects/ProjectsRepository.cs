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
                            ProjectStatus = x.ProjectStatus,
                            StatusDescription = x.StatusDescription,
                            ProjectScope = x.ProjectScope,
                            BidDate = x.BidDate,
                            ActiveDate = x.ActiveDate
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
                            ProjectStatus = Project.ProjectStatus,
                            StatusDescription = Project.StatusDescription.Trim(),
                            ProjectManager = $"{Project.ProjectManager.FirstName} {Project.ProjectManager.LastName}",
                            ArchitectEngineer = $"{Project.ArchitectEngineer.FirstName} {Project.ArchitectEngineer.LastName}",
                            Secretary = $"{Project.Secretary.FirstName} {Project.Secretary.LastName}",
                            ProjectUser = $"{Project.ProjectUser.FirstName} {Project.ProjectUser.LastName}",
                            Consultant = $"{Project.Consultant.ConsultantName}",
                            ConsultantDesc = Project.Consultant.Description,
                            Contractor = $"{Project.Contractor.ContractorName}",
                            ProjectType = Project.ProjectType.Name,
                            ActiveDate = Project.ActiveDate,
                            BidDate = Project.BidDate,
                            ProjectScope = Project.ProjectScope,
                            AgendaSetting = Project.AgendaSetting,
                            BidOpen = Project.BidOpen,
                            ConstructionBidAward = Project.ConstructionBidAward,
                            DesignComplete = Project.DesignComplete,
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
