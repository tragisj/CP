namespace FNSB.Publicworks.Projects.DataLayer.Model.Reporting
{
    public class ManagerSummary
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public int Count { get; set; }
        public decimal? TotalAllocation { get; set; }
        public decimal? AmountComplete { get; set; }
    }
}
