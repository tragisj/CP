using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.Users")]
    public partial class User
    {
        [Key]
        public int ppu_recordid { get; set; }

        [StringLength(255)]
        public string firstname { get; set; }

        [StringLength(255)]
        public string lastname { get; set; }
    }
}
