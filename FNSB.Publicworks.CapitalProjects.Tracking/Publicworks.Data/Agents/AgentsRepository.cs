using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Data.Context;
using Publicworks.Entities.Agents;
using Publicworks.Entities.Projects.ViewModels;

namespace Publicworks.Data.Agents
{
    public class AgentsRepository
    {


        public List<ConsultantDisplayViewModel> GetConsultants()
        {
            using (var context = new ApplicationDbContext())
            {

                List<Consultant> consultants = new List<Consultant>();
                consultants = context.Consultants.AsNoTracking().ToList();

                if (consultants != null)
                {
                    List<ConsultantDisplayViewModel> consultantsDisplay = new List<ConsultantDisplayViewModel>();

                    foreach (var x in consultants)
                    {
                        var consultantDisplay = new ConsultantDisplayViewModel()
                        {
                            CustomerID = x.ConsultantID,
                            ConsultantName = x.ConsultantName,
                            Description = x.Description
                        };
                        consultantsDisplay.Add(consultantDisplay);
                    }

                    return consultantsDisplay;
                }
                return null;
            }
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
    }
}
