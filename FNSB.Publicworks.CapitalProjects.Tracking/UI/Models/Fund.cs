using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.Funds")]
    public partial class Fund
    {
        [Key]
        public int ppf_recordid { get; set; }

        [StringLength(10)]
        public string ppf_funding { get; set; }

        [StringLength(10)]
        public string ppf_department { get; set; }

        [StringLength(10)]
        public string ppf_glkey { get; set; }

        [StringLength(255)]
        public string ppf_glkey_name { get; set; }

        [DisplayFormat(DataFormatString = "{C}")]
        public decimal? ppf_budget { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? ppf_expenditures { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? ppf_encumbrances { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? ppf_balance { get; set; }

        public int? ppm_recordid { get; set; }
    }
}
