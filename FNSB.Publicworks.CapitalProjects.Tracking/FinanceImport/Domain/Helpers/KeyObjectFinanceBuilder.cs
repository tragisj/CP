using System.Collections.Generic;
using System.Linq;
using FNSB.PW.Finance.Import.Data;

namespace FNSB.PW.Finance.Import.Domain.Helpers
{
    public class KeyObjectFinanceBuilder
    {
        public List<OneSolutionBudgetActualDataList> OneSolutionBudgetActualsList { get; set; }

        public List<string> GeneralLedgerKeyList { get; set; }

        public Dictionary<string, List<KeyPartDetail>> KeyPartDetailDictionary { get; set; }

        public KeyObjectFinanceBuilder()
        {
            //Query the Database for the BudgetToActual Data and build the List of KeyObjectFinance objects
            //----------------------------------------------------------------------------------------------

            //new instance of the public property List<KeyObjectFinance>
            OneSolutionBudgetActualsList = new List<OneSolutionBudgetActualDataList>();

            //init OneSolutionBudActPersist to query and return the full public works budget_to_actual raw data package
            var persist = new OneSolutionBudActPersist();

            //assign budget_to_actual raw data package to List<OneSolutionBudgetActualDataList>
            OneSolutionBudgetActualsList = persist.FinancialKeyObjects;

            //Generate a distinct General Ledger Key List and return a unique list of GLKeys contained in the KeyObjects list.
            GeneralLedgerKeyList = new List<string>();
            GeneralLedgerKeyList = OneSolutionBudgetActualsList.Select(k => k.Key).Distinct().ToList();

            ////Use distinct key list to get key part detail on the project tracking keys
            //KeyPartDetailDictionary = new Dictionary<string, List<KeyPartDetail>>();
            //KeyPartDetailDictionary = koData.KeyPartData(GeneralLedgerKeyList);
        }


        //public KeyPartDetail KeyPartLookup()
        //{

        //    //KeyObject Data Instance created to query and return full public works BudAct data package
        //    var koData = new KeyObjectFinanceData();

        //    throw new System.NotImplementedException();


        //}
    }
}
