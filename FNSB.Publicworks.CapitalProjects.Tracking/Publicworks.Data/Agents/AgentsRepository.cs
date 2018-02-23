using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Data.Context;
using Publicworks.Entities.Agents;
using Publicworks.Entities.Projects.ViewModels;
using Publicworks.Entities.Projects.ViewModels.Agents;

namespace Publicworks.Data.Agents
{
    public class AgentsRepository
    {
        //Consultants 
        public List<ConsultantViewModel> GetConsultants()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Consultant> consultants = new List<Consultant>();
                consultants = context.Consultants.AsNoTracking().ToList();

                if (consultants != null)
                {
                    List<ConsultantViewModel> consultantsDisplay = new List<ConsultantViewModel>();

                    foreach (var x in consultants)
                    {
                        var consultantDisplay = new ConsultantViewModel()
                        {
                            ConsultantID = x.ConsultantID,
                            ConsultantName = x.ConsultantName,
                            Description = x.Description
                        };
                        consultantsDisplay.Add(consultantDisplay);
                    }
                    return consultantsDisplay;
                } 
            }
            return null;
        }

        public ConsultantEditViewModel GetConsultant(Guid ConsultantId)
        {
            if (ConsultantId != Guid.Empty)
            {
                using (var context = new ApplicationDbContext())
                {
                    var Consuntant = context.Consultants.AsNoTracking()
                        .Where(x => x.ConsultantID == ConsultantId)
                        .SingleOrDefault();

                    if (Consuntant != null)
                    {
                        var ConsultantEditVm = new ConsultantEditViewModel()
                        {
                            ConsultantID = Consuntant.ConsultantID.ToString("D"),
                            ConsultantName = Consuntant.ConsultantName.Trim(),
                            Description = Consuntant.Description.Trim()
                        };

                        return ConsultantEditVm;
                    }
                }
            }
            return null;
        }


        public ConsultantEditViewModel CreateConsultant()
        {

            var consultant = new ConsultantEditViewModel()
            {
                ConsultantID = Guid.NewGuid().ToString(),
                ConsultantName = string.Empty,
                Description = string.Empty
            };
            return consultant;
        }


        public bool SaveConsultant(ConsultantEditViewModel consultantedit)
        {
            if (consultantedit != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(consultantedit.ConsultantID, out Guid newGuid))
                    {
                        var consultant = new Consultant()
                        {
                            ConsultantID = newGuid,
                            ConsultantName = consultantedit.ConsultantName,
                            Description = consultantedit.Description
                        };

                        context.Consultants.Add(consultant);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UpdateConsultant(ConsultantEditViewModel model)
        {
            if (model != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(model.ConsultantID, out Guid newGuid))
                    {
                        var consultant = context.Consultants.Find(newGuid);
                        if (consultant != null)
                        {
                            consultant.ConsultantName = model.ConsultantName;
                            consultant.Description = model.Description;
                        }

                        var result = context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }




        //Contractor
        public List<ContractorViewModel> GetContractors()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Contractor> contractors = new List<Contractor>();
                contractors = context.Contractors.AsNoTracking().ToList();

                if (contractors != null)
                {
                    List<ContractorViewModel> contractorsDisplay = new List<ContractorViewModel>();

                    foreach (var x in contractors)
                    {
                        var contractorDisplay = new ContractorViewModel()
                        {
                            ContractorID = x.ContractorID,
                            ContractorName = x.ContractorName,
                            Description = x.Description
                        };
                        contractorsDisplay.Add(contractorDisplay);
                    }
                    return contractorsDisplay;
                }
            }
            return null;
        }

        public ContractorEditViewModel GetContractor(Guid ContractorId)
        {
            if (ContractorId != Guid.Empty)
            {
                using (var context = new ApplicationDbContext())
                {
                    var Contractor = context.Contractors.AsNoTracking()
                        .Where(x => x.ContractorID == ContractorId)
                        .SingleOrDefault();

                    if (Contractor != null)
                    {
                        var ContractorEditVm = new ContractorEditViewModel()
                        {
                            ContractorID = Contractor.ContractorID.ToString("D"),
                            ContractorName = Contractor.ContractorName.Trim(),
                            Description = Contractor.Description.Trim()
                        };

                        return ContractorEditVm;
                    }
                }
            }
            return null;
        }


        public ContractorEditViewModel CreateContractor()
        {
            var contractor = new ContractorEditViewModel()
            {
                ContractorID = Guid.NewGuid().ToString(),
                ContractorName = string.Empty,
                Description = string.Empty
            };
            return contractor;
        }


        public bool SaveContractor(ContractorEditViewModel contractoredit)
        {
            if (contractoredit != null)
            {
                using (var context = new ApplicationDbContext())
                {

                    if (Guid.TryParse(contractoredit.ContractorID, out Guid newGuid))
                    {
                        var contractor = new Contractor()
                        {
                            ContractorID = newGuid,
                            ContractorName = contractoredit.ContractorName,
                            Description = contractoredit.Description
                        };

                        context.Contractors.Add(contractor);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UpdateContractor(ContractorEditViewModel model)
        {
            if (model != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    if (Guid.TryParse(model.ContractorID, out Guid newGuid))
                    {
                        var contractor = context.Contractors.Find(newGuid);
                        if (contractor != null)
                        {
                            contractor.ContractorName = model.ContractorName;
                            contractor.Description = model.Description;
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
