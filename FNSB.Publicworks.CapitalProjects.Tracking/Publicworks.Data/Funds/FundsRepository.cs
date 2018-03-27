using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Publicworks.Data.Context;
using Publicworks.Entities.Funds;
using Publicworks.Entities.Projects.ViewModels.Funds;
using Publicworks.Finance.OneSolution.Domain.Helpers;

namespace Publicworks.Data.Funds
{
    public class FundsRepository
    {
        public List<KeyStatusViewModel> GetOneSolutionGeneralLedgerKeyStatusDesc(bool active)
        {

            List<KeyStatusViewModel> fundsViewData = new List<KeyStatusViewModel>();

            using (var context = new ApplicationDbContext())
            {

                var proc = active ? "SelectOSActiveKeyStatusDesc" : "SelectOSKeyStatusDesc";
                var spd = context.Database.SqlQuery<OneSolutionFinance>(proc);

                foreach (var key in spd)
                {
                    KeyStatusViewModel x = new KeyStatusViewModel
                    {
                        GLKey = key.GeneralLedgerKey,
                        GeneralLedgerDescription = key.GeneralLedgerDesc,
                        GlKeyStatus = key.KeyStatus
                    };

                    fundsViewData.Add(x);
                }
                return fundsViewData;
            }
        }

        public List<KeyBackgroundViewModel> GetOneSolutionGeneralLedgerKeyPartDetail(string glkey)
        {
            using (var context = new ApplicationDbContext())
            {


                List<KeyBackgroundViewModel> kdl = new List<KeyBackgroundViewModel>();
                var glparam = new SqlParameter("@GLkey", SqlDbType.VarChar, 10) {Value = glkey};

                var kd = context.Database.SqlQuery<OneSolutionKeyPartDetail>("SelectOSKeyPartDetails @GLkey", glparam);

                if (kd != null)
                {
                    foreach (var k in kd)
                    {
                        KeyBackgroundViewModel x = new KeyBackgroundViewModel()
                        {
                            GlKey = glkey,
                            GroupDescription = k.Description,
                            GroupId = k.Id,
                            GroupName = k.Name,
                            PartNo = k.Number,
                            PartValue = k.Value
                        };
                        kdl.Add(x);
                    }

                    return kdl;
                }

                return null;
            }
        }


        public KeyDetailViewModel GetOneSolutionBudgetActualDetail(string glkey)
        {
            KeyDetailViewModel kd = new KeyDetailViewModel();



            var budgetsCalcs = new BudgetCalculations(ref budgetActualData, ref glKeyList);

            var balance = budgetsCalcs.BuildBudgetBalances("WB", 2018);






            return null;


        }
    }
}
