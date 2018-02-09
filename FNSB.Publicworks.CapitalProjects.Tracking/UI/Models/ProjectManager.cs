using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.ProjectManagers")]
    public partial class ProjectManager
    {
        public ProjectManager()
        {
        }

        [Key]
        public int ppr_recordid { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        public int? order { get; set; }
    }
}
