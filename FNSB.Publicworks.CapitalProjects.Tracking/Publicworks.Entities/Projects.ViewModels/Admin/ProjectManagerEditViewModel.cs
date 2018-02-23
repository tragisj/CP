using System.ComponentModel.DataAnnotations;

namespace Publicworks.Entities.Projects.ViewModels.Admin
{
    public class ProjectManagerEditViewModel
    {
        [Display(Name = "Project Manager ID")]
        public string ProjectManagerID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
