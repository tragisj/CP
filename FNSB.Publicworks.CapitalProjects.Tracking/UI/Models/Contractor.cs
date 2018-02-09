using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.Contractors")]
    public partial class Contractor
    {
        [Key]
        public int ppn_recordid { get; set; }

        [StringLength(255)]
        public string contractorname { get; set; }
    }
}
