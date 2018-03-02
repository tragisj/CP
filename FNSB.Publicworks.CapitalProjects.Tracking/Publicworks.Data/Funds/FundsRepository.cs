using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Data.Context;
using Publicworks.Entities.Funds;
using Publicworks.Entities.Projects.ViewModels.Funds;

namespace Publicworks.Data.Funds
{
    public class FundsRepository
    {
        public List<FundKeysViewModel> GetGlKeys()
        {
            using (var context = new ApplicationDbContext())
            {
                List<GeneralLedgerKey> gkeys = new List<GeneralLedgerKey>();
                gkeys = context.GeneralLedgerKeys.AsNoTracking().ToList();

                if (gkeys != null)
                {
                    List<FundKeysViewModel> fundsDisplay = new List<FundKeysViewModel>();

                    foreach (var x in gkeys)
                    {

                        var fundDisplay = new FundKeysViewModel()
                        {
                            ActiveKey = x.ActiveKey,
                            GLKey = x.GLKey
                        };

                        fundsDisplay.Add(fundDisplay);
                    }

                    return fundsDisplay;
                }
            }
            return null;
        }
    }
}
