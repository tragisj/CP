using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels.Funds
{
    public class FundKeysViewModel
    {

        [Display(Name = "GL Key ID")]
        public Guid GeneralLedgerKeyID { get; set; }

        [Display(Name = "GL Key")]
        public string GLKey { get; set; }

        [Display(Name = "Imported from Finance")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FinanceImportDate { get; set; }

        [Display(Name = "Key Status")]
        public bool ActiveKey { get; set; }




    }
}
