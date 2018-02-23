using System.ComponentModel.DataAnnotations;

namespace Publicworks.Entities.Projects.ViewModels.Agents
{
    public class ConsultantEditViewModel
    {
        [Required]
        [Display(Name = "Customer ID")]
        public string ConsultantID { get; set; }

        [Required]
        [Display(Name = "Consultant Name")]
        [StringLength(128)]
        public string ConsultantName { get; set; }

        [Display(Name = "Consultant Description")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
