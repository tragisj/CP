using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Publicworks.Entities.Projects.ViewModels.Funds
{
    public class KeyStatusViewModel
    {

        [Display(Name = "General Ledger Key ID")]
        public Guid GeneralLedgerKeyID { get; set; }

        [Display(Name = "GL Key")]
        public string GLKey { get; set; }

        [Display(Name = "Key Status")]
        public string GlKeyStatus { get; set; }

        [Display(Name = "GL Description")]
        public string GeneralLedgerDescription { get; set; }



    }
}
