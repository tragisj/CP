using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Data.Context;
using Publicworks.Entities.Admin;
using Publicworks.Entities.Projects.ViewModels.Admin;

namespace Publicworks.Data.Admin
{
    public class ProjectUserRepository
    {
        public List<ProjectUserViewModel> GetProjectUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                List<ProjectUser> users = new List<ProjectUser>();
                 users = context.Users.AsNoTracking()
                    .ToList();

                if (users != null)
                {
                    List<ProjectUserViewModel> usersDisplay = new List<ProjectUserViewModel>();
                    foreach (var x in users)
                    {
                        var userDisplay = new ProjectUserViewModel()
                        {
                            ProjectUserID = x.ProjectUserID,
                            FirstName = x.FirstName.Trim(),
                            LastName = x.LastName.Trim()
                        };
                        usersDisplay.Add(userDisplay);
                    }
                    return usersDisplay;
                }
            }
            return null;
        }


        public ProjectUserEditViewModel GetProjectUser(Guid projectUserId)
        {
            if (projectUserId != Guid.Empty)
            {
                using (var context = new ApplicationDbContext())
                {
                    var projectUser = context.Users.AsNoTracking()
                        .Where(x => x.ProjectUserID == projectUserId)
                        .SingleOrDefault();
                    if (projectUser != null)
                    {
                        var projectUserEditVm = new ProjectUserEditViewModel()
                        {
                            ProjectUserID = projectUser.ProjectUserID.ToString("D"),
                            FirstName = projectUser.FirstName.Trim(),
                            LastName = projectUser.LastName.Trim()
                        };

                        return projectUserEditVm;
                    }
}
            }
            return null;
        }

        
        public ProjectUserEditViewModel CreateProjectUser()
        {

            var projectUser = new ProjectUserEditViewModel()
            {
                ProjectUserID = Guid.NewGuid().ToString(),
                FirstName = string.Empty,
                LastName = string.Empty
            };

            return projectUser;
        }


        public bool SaveProjectUser(ProjectUserEditViewModel projectUserEdit)
        {
            if (projectUserEdit != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(projectUserEdit.ProjectUserID, out Guid newGuid))
                    {
                        var projectUser = new ProjectUser()
                        {
                            ProjectUserID = newGuid,
                            FirstName = projectUserEdit.FirstName,
                            LastName = projectUserEdit.LastName
                        };

                        context.Users.Add(projectUser);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UpdateProjectUser(ProjectUserEditViewModel model)
        {
            if (model != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(model.ProjectUserID, out Guid newGuid))
                    {
                        var user = context.Users.Find(newGuid);
                        if (user != null)
                        {
                            user.FirstName = model.FirstName;
                            user.LastName = model.LastName;
                        }

                        var result = context.SaveChanges();
                        if (result == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
