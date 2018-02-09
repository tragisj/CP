using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.Consultants")]
    public partial class Consultant
    {
        [Key]
        public int ppc_recordid { get; set; }

        [StringLength(255)]
        public string consultantname { get; set; }
    }
}
