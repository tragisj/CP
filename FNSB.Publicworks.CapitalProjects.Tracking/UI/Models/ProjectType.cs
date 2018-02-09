using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.ProjectTypes")]
    public partial class ProjectType
    {
        [Key]
        public int ppt_recordid { get; set; }

        [StringLength(255)]
        public string category { get; set; }
    }
}
