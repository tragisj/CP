using System.Collections.Generic;

namespace FNSB.PW.Finance.Import.Domain
{
    public class OneSolutionBudgetActualDataList
    {
        public int FiscalYear { get; set; }
        public string Key { get; set; }
        public string Object { get; set; }
        public string JobLedgerKey { get; set; }
        public bool Status { get; set; }
        public string MediumDesc { get; set; }
        public string LongDesc { get; set; }
        public Budget Budget { get; set; }
        public Encumbrances Encumbrances { get; set; }
        public Actual Actuals { get; set; }
        public Budget Balances { get; set; }

    }
}
