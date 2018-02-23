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
    public class SecretaryRepository
    {
        public List<SecretaryViewModel> GetSecretaries()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Secretary> secretaries = new List<Secretary>();
                secretaries = context.Secretaries.AsNoTracking()
                    .ToList();

                if (secretaries != null)
                {
                    List<SecretaryViewModel> secretarysDisplay = new List<SecretaryViewModel>();
                    foreach (var x in secretaries)
                    {
                        var secDisplay = new SecretaryViewModel()
                        {
                            SecretaryID = x.SecretaryID,
                            FirstName = x.FirstName,
                            LastName = x.LastName
                        };
                        secretarysDisplay.Add(secDisplay);
                    }
                    return secretarysDisplay;
                }
            }
            return null;
        }


        public SecretaryEditViewModel GetSecretary(Guid secretaryId)
        {
            if (secretaryId != Guid.Empty)
            {
                using (var context = new ApplicationDbContext())
                {
                    var projectManager = context.Secretaries.AsNoTracking()
                        .Where(x => x.SecretaryID == secretaryId)
                        .SingleOrDefault();
                    if (projectManager != null)
                    {
                        var secretaryEditVm = new SecretaryEditViewModel()
                        {
                            SecretaryID = projectManager.SecretaryID.ToString("D"),
                            FirstName = projectManager.FirstName.Trim(),
                            LastName = projectManager.LastName.Trim()
                        };

                        return secretaryEditVm;
                    }
                }
            }
            return null;
        }

        //Project Managers
        public SecretaryEditViewModel CreateSecretary()
        {

            var projectmgr = new SecretaryEditViewModel()
            {
                SecretaryID = Guid.NewGuid().ToString(),
                FirstName = String.Empty,
                LastName = String.Empty
            };

            return projectmgr;
        }

        public bool SaveSecretary(SecretaryEditViewModel secretaryEdit)
        {
            if (secretaryEdit != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(secretaryEdit.SecretaryID, out Guid newGuid))
                    {
                        var secretary = new Secretary
                        {
                            SecretaryID = newGuid,
                            FirstName = secretaryEdit.FirstName,
                            LastName = secretaryEdit.LastName
                        };

                        context.Secretaries.Add(secretary);
                        context.SaveChanges();
                        return true;
                    }
                }
            }

            return false;
        }


        public bool UpdateSecretary(SecretaryEditViewModel model)
        {
            if (model != null)
            {

                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(model.SecretaryID, out Guid newGuid))
                    {
                        var pm = context.Secretaries.Find(newGuid);
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
