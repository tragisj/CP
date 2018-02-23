using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Data.Context;
using System.Data.Entity;
using Publicworks.Entities.Admin;
using Publicworks.Entities.Projects.ViewModels;
using Publicworks.Entities.Projects.ViewModels.Admin;

namespace Publicworks.Data.Admin
{
    public class ProjectManagerRepository
    {
        public List<ProjectManagerViewModel> GetProjectManagers()
        {
            using (var context = new ApplicationDbContext())
            {
                List<ProjectManager> managers = new List<ProjectManager>();
                managers = context.ProjectManagers.AsNoTracking()
                    .ToList();

                if (managers != null)
                {
                    List<ProjectManagerViewModel> managersDisplay = new List<ProjectManagerViewModel>();
                    foreach (var x in managers)
                    {
                        var managerDisplay = new ProjectManagerViewModel()
                        {
                            ProjectManagerID = x.ProjectManagerID,
                            FirstName = x.FirstName,
                            LastName = x.LastName
                        };
                        managersDisplay.Add(managerDisplay);
                    }
                    return managersDisplay;
                }
            }
            return null;
        }


        public ProjectManagerEditViewModel GetProjectManager(Guid projectManagerId)
        {
            if (projectManagerId != Guid.Empty)
            {
                using (var context = new ApplicationDbContext())
                {
                    var projectManager = context.ProjectManagers.AsNoTracking()
                        .Where(x => x.ProjectManagerID == projectManagerId)
                        .SingleOrDefault();
                    if (projectManager != null)
                    {
                        var projectManagerEditVm = new ProjectManagerEditViewModel()
                        {
                            ProjectManagerID = projectManager.ProjectManagerID.ToString("D"),
                            FirstName = projectManager.FirstName.Trim(),
                            LastName = projectManager.LastName.Trim()
                        };

                        return projectManagerEditVm;
                    }
                }
            }
            return null;
        }


        //Project Managers
        public ProjectManagerEditViewModel CreateProjectManager()
        {

            var projectmgr = new ProjectManagerEditViewModel()
            {
                ProjectManagerID = Guid.NewGuid().ToString(),
                FirstName = String.Empty,
                LastName = String.Empty
            };

            return projectmgr;
        }

        public bool SaveProjectManager(ProjectManagerEditViewModel projectManagerEdit)
        {
            if (projectManagerEdit != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(projectManagerEdit.ProjectManagerID, out Guid newGuid))
                    {
                        var pm = new ProjectManager
                        {
                            ProjectManagerID = newGuid,
                            FirstName = projectManagerEdit.FirstName,
                            LastName = projectManagerEdit.LastName
                        };

                        context.ProjectManagers.Add(pm);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }


        public bool UpdateProjectManager(ProjectManagerEditViewModel model)
        {
            if (model != null)
            {

                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(model.ProjectManagerID, out Guid newGuid))
                    {
                        var pm = context.ProjectManagers.Find(newGuid);
                        if (pm != null)
                        {
                            pm.FirstName = model.FirstName;
                            pm.LastName = model.LastName;
                        }

                        var result = context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
