using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.FundingTypes")]
    public partial class FundingType
    {
        [Key]
        public Guid ppy_recordid { get; set; }

        [StringLength(20)]
        public string fundsource { get; set; }

        [StringLength(255)]
        public string fundname { get; set; }
    }
}
