using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Data.Context;
using Publicworks.Entities.Admin;
using Publicworks.Entities.Projects.ViewModels.Admin;

namespace Publicworks.Data.Admin
{
    public class ArchitectEngineerRepository
    {

        public List<ArchitectEngineerViewModel> GetArchitectEngineers()
        {
            using (var context = new ApplicationDbContext())
            {
                List<ArchitectEngineer> ae = new List<ArchitectEngineer>();
                ae = context.ArchitectEngineers.AsNoTracking()
                    .ToList();

                if (ae != null)
                {
                    List<ArchitectEngineerViewModel> managersDisplay = new List<ArchitectEngineerViewModel>();
                    foreach (var x in ae)
                    {
                        var aeDisplay = new ArchitectEngineerViewModel()
                        {
                            ArchitectEngineerID = x.ArchitectEngineerID,
                            FirstName = x.FirstName,
                            LastName = x.LastName
                        };
                        managersDisplay.Add(aeDisplay);
                    }
                    return managersDisplay;
                }
            }
            return null;
        }

        public List<ArchitectEngineerViewModel> GetArchitectEngineersWithProjects()
        {
            using (var context = new ApplicationDbContext())
            {
                List<ArchitectEngineer> ae = new List<ArchitectEngineer>();
                ae = context.ArchitectEngineers.AsNoTracking()
                    .Include(x => x.Projects)
                    .ToList();

                if (ae != null)
                {
                    List<ArchitectEngineerViewModel> architectsList = new List<ArchitectEngineerViewModel>();
                    foreach (var x in ae)
                    {
                        var aeDisplay = new ArchitectEngineerViewModel()
                        {
                            ArchitectEngineerID = x.ArchitectEngineerID,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            Projects = x.Projects
                        };
                        architectsList.Add(aeDisplay);
                    }
                    return architectsList;
                }
            }
            return null;
        }


        public ArchitectEngineerEditViewModel GetArchitectEngineer(Guid arcId)
        {
            if (arcId != Guid.Empty)
            {
                using (var context = new ApplicationDbContext())
                {
                    var architectEngineer = context.ArchitectEngineers.AsNoTracking()
                        .Where(x => x.ArchitectEngineerID == arcId)
                        .SingleOrDefault();
                    if (architectEngineer != null)
                    {
                        var architectEngineerEditVm = new ArchitectEngineerEditViewModel()
                        {
                            ArchitectEngineerID = architectEngineer.ArchitectEngineerID.ToString("D"),
                            FirstName = architectEngineer.FirstName.Trim(),
                            LastName = architectEngineer.LastName.Trim()
                        };

                        return architectEngineerEditVm;
                    }
                }
            }
            return null;
        }


        public ArchitectEngineerEditViewModel CreateArchitectEngineer()
        {

            var architect = new ArchitectEngineerEditViewModel()
            {
                ArchitectEngineerID = Guid.NewGuid().ToString(),
                FirstName = String.Empty,
                LastName = String.Empty
            };

            return architect;
        }


        public bool SaveArchitectEngineer(ArchitectEngineerEditViewModel architectEdit)
        {
            if (architectEdit != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(architectEdit.ArchitectEngineerID, out Guid newGuid))
                    {
                        var ae = new ArchitectEngineer()
                        {
                            ArchitectEngineerID = newGuid,
                            FirstName = architectEdit.FirstName,
                            LastName = architectEdit.LastName
                        };

                        context.ArchitectEngineers.Add(ae);
                        context.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }


        public bool UpdateArchitectEngineer(ArchitectEngineerEditViewModel model)
        {
            if (model != null)
            {

                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(model.ArchitectEngineerID, out Guid newGuid))
                    {
                        var ae = context.ArchitectEngineers.Find(newGuid);
                        if (ae != null)
                        {
                            ae.FirstName = model.FirstName;
                            ae.LastName = model.LastName;
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
