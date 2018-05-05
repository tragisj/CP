using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Publicworks.Data.Context;
using Publicworks.Entities.Funds;
using Publicworks.Entities.Projects.ViewModels.Funds;
using Publicworks.Finance.OneSolution.Data;
using Publicworks.Finance.OneSolution.Data.Repository;
using Publicworks.Finance.OneSolution.Entities;

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
            KeyDetailViewModel model = new KeyDetailViewModel();
            PubworksRepository repository = new PubworksRepository();
            ProjectTrackingFinance x = repository.GetGlKeyBalanceByKey(glkey);

            model.Actual = x.Actuals.ToString("C");
            model.Budget =  x.Budget.ToString("C");
            model.Encumbrances = x.Encumbrance.ToString("C");
            model.Balance = x.Balance.ToString("C");
            model.GLKey = glkey;
            return model;
        }


        public List<KeyDetailViewModel> GetGlKeyDataByProjectId(Guid projectId)
        {
            if (projectId != Guid.Empty)
            {
                using (var context = new ApplicationDbContext())
                {

                    var project = context.Projects.AsNoTracking()
                        .Where(x => x.ProjectID == projectId).SingleOrDefault();

                    if (project != null)
                    {

                        List<string> keys = new List<string>();
                        foreach (var key in project.GeneralLedgerKeys)
                        {
                            keys.Add(key.GLKey);
                        }

                        List<KeyDetailViewModel> modelList = new List<KeyDetailViewModel>();
                        PubworksRepository repository = new PubworksRepository();
                        List<ProjectTrackingFinance> keyDetailList = repository.GetGlKeyBalanceByKeyList(keys);


                        foreach (var x in keyDetailList)
                        {
                            KeyDetailViewModel k = new KeyDetailViewModel
                            {
                                Actual = x.Actuals.ToString("C"),
                                Budget = x.Budget.ToString("C"),
                                Encumbrances = x.Encumbrance.ToString("C"),
                                Balance = x.Balance.ToString("C"),
                                GLKey = x.GeneralLedgerKey
                            };

                            modelList.Add(k);
                        }

                        return modelList;
                    }
                }
            }

            return null;
        }
    }
}
