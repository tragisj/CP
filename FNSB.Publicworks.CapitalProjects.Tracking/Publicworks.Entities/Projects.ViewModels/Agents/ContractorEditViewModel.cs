using System.ComponentModel.DataAnnotations;

namespace Publicworks.Entities.Projects.ViewModels.Agents
{
    public class ContractorEditViewModel
    {
        [Required]
        [Display(Name = "Contractor ID")]
        public string ContractorID { get; set; }

        [Required]
        [Display(Name = "Contractor Name")]
        [StringLength(128)]
        public string ContractorName { get; set; }

        [Display(Name = "Contractor Description")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
