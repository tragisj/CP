using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Data.Context;
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
                            StatusDescription = x.StatusDescription
                            
                            
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
                        var projectEditVm = new ProjectEditViewModel()
                        {
                            ProjectID = Project.ProjectID.ToString("D"),
                            ProjectName = Project.ProjectName.Trim(),
                            ProjectNumber = Project.ProjectNumber.Trim(),
                            ProjectStatus = Project.ProjectStatus,
                            StatusDescription = Project.StatusDescription.Trim()
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
