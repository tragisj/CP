namespace FNSB.Publicworks.Projects.DataLayer.Model.Reporting
{
    public class ProjectTypeSummary
    {
        public int ProjectTypeId { get; set; }
        public string ProjectType { get; set; }
        public int Count { get; set; }
        public decimal? TotalAllocation { get; set; }
        public decimal? AmountComplete { get; set; }
    }
}
