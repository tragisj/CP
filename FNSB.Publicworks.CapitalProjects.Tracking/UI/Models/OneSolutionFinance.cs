using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FNSB.PW.Projects.Web.Models
{
    [Table("Publicworks.OneSolutionFinance")]
    public partial class OneSolutionFinance
    {   
        
        public int Id { get; set; }

        [Key]
        public string GlKey { get; set; }

        public int ProjectId { get; set; }


        
    }
}