using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.ArchitectEngineers")]
    public partial class ArchitectEngineer
    {
        [Key]
        public int recordid { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        public int? order { get; set; }
    }
}
