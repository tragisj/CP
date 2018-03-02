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

        public List<ProjectViewIndexModel> GetProjects()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Project> projects = new List<Project>();
                projects = context.Projects.AsNoTracking().ToList();

                if (projects != null)
                {
                    List<ProjectViewIndexModel> projectsDisplay = new List<ProjectViewIndexModel>();

                    foreach (var x in projects)
                    {
                        var projectDisplay = new ProjectViewIndexModel()
                        {
                            ProjectID = x.ProjectID,
                            ProjectName = x.ProjectName,
                            ProjectNumber = x.ProjectNumber,
                            ActiveProject = x.ActiveProject,
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
                    var project = context.Projects.AsNoTracking()
                        .Where(x => x.ProjectID == projectId)
                        .SingleOrDefault();

                    if (project != null)
                    {
                        var projectEditVm = new ProjectViewModel()
                        {
                            ProjectID = project.ProjectID,
                            ProjectName = project.ProjectName.Trim(),
                            ProjectNumber = project.ProjectNumber.Trim(),
                            ActiveProject = project.ActiveProject,
                            StatusDescription = project.StatusDescription.Trim(),
                            ProjectManager = $"{project.ProjectManager.FirstName} {project.ProjectManager.LastName}",
                            ArchitectEngineer = $"{project.ArchitectEngineer.FirstName} {project.ArchitectEngineer.LastName}",
                            Secretary = $"{project.Secretary.FirstName} {project.Secretary.LastName}",
                            ProjectUser = $"{project.ProjectUser.FirstName} {project.ProjectUser.LastName}",
                            Consultant = $"{project.Consultant.ConsultantName}",
                            ConsultantDesc = project.Consultant.Description,
                            Contractor = $"{project.Contractor.ContractorName}",
                            ProjectType = project.ProjectType.Name,
                            ActiveDate = project.Activated,
                            BidOpening = project.BidOpening,
                            ProjectScope = project.ProjectScope,
                            AgendaSetting = project.AgendaSetting,
                            ConstructionBidAward = project.ConstructionBidAward,
                            DesignCompleted = project.DesignCompleted,
                            OriginalBidDate = project.OriginalBidDate,
                            PercentDesignComplete = project.PercentDesignComplete,
                            ChangeOrders = project.ChangeOrders,
                            ClosedDate = project.ClosedDate,
                            ConsultantFees = project.ConsultantFees,
                            ContractAmount = project.ContractAmount,
                            FinalInspection = project.FinalInspection,
                            SubstantialCompletion = project.SubstantialCompletion,
                            WarrantyPeriodEnds = project.WarrantyPeriodEnds,
                            AdvertiseForBid = project.AdvertiseForBid,
                            AssemblyApproval = project.AssemblyApproval,
                            CompletedProject = project.CompletedProject,
                            ConsultantBidAward = project.ConsultantBidAward,
                            ContractAmendments = project.ContractAmendments,
                            NoticeToProceed = project.NoticeToProceed,
                            PercentConstructionComplete = project.PercentConstructionComplete
                        };

                        return projectEditVm;
                    }
                }
            }
            return null;
        }




        public bool UpdateProject(ProjectEditViewModel model)
        {
            throw new NotImplementedException();
        }





    }
}
