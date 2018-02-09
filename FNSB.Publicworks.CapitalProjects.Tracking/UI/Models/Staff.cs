using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.Staff")]
    public partial class Staff
    {
        [Key]
        public int Recordid { get; set; }

        public bool ActiveEmployee { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        public byte? DisplaySorting { get; set; }
    }
}
