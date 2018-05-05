using System;
using System.Collections.Generic;
using System.Linq;
using Publicworks.Finance.OneSolution.Entities;

namespace Publicworks.Finance.OneSolution.Data.Repository
{
    public class PubworksRepository
    {

        public ProjectTrackingFinance GetGlKeyBalanceByKey(string glkey)
        {
            BudgetData bd = new BudgetData();
            EncumbranceData en = new EncumbranceData();
            ActualsData ac = new ActualsData();

            List<BudgetBalance> blist = bd.GetBudgetBalanceForGlKey(glkey);
            decimal budget = blist.Sum(s => s.Amount);
            decimal encumbrance = en.GetEncubranceBalanceForGlKey(glkey);
            decimal actuals = ac.GetActualsBalanceForGlKey(glkey);
            decimal balance = budget - (encumbrance + actuals);

            var ptf = new ProjectTrackingFinance
            {
                GeneralLedgerKey = glkey,
                Budget = budget,
                Encumbrance = encumbrance,
                Actuals = actuals,
                Balance = balance
            };

            return ptf;
        }

        public List<ProjectTrackingFinance> GetGlKeyBalanceByKeyList(List<string> keyList)
        {
            BudgetData bd = new BudgetData();
            EncumbranceData en = new EncumbranceData();
            ActualsData ac = new ActualsData();
            List<ProjectTrackingFinance> ptl = new List<ProjectTrackingFinance>();

            foreach (var glkey in keyList)
            {
                List<BudgetBalance> blist = bd.GetBudgetBalanceForGlKey(glkey);
                decimal budget = blist.Sum(s => s.Amount);
                decimal encumbrance = en.GetEncubranceBalanceForGlKey(glkey);
                decimal actuals = ac.GetActualsBalanceForGlKey(glkey);
                decimal balance = budget - (encumbrance + actuals);

                var x = new ProjectTrackingFinance
                {
                    GeneralLedgerKey = glkey,
                    Budget = budget,
                    Encumbrance = encumbrance,
                    Actuals = actuals,
                    Balance = balance
                };

                ptl.Add(x);
            }

            return ptl;
        }
    }
}
