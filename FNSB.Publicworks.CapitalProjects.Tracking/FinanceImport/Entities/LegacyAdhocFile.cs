namespace Publicworks.Finance.OneSolution.Entities
{
    public class AdhocFile
    {
        public string FundGroup { get; set; }
        public string Department { get; set; }
        public string GeneralLedgerKey { get; set; }
        public string ProjectLongDesc { get; set; }
        public decimal BudgetBalance { get; set; }
        public decimal ActualsBalance { get; set; }
        public decimal EncumbranceBalance { get; set; }
    }
}
