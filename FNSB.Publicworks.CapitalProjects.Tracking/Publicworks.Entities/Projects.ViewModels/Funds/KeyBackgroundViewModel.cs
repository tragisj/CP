using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels.Funds
{
    public class KeyBackgroundViewModel
    {



        [Display(Name = "General Ledger Key")]
        public string GlKey { get; set; }

        [Display(Name = "Key Part No.")]
        public string PartNo { get; set; }

        [Display(Name = "Part Value")]
        public string PartValue { get; set; }

        [Display(Name = "Group ID")]
        public string GroupId { get; set; }

        [Display(Name = "Group Name")]
        public string GroupName { get; set; }

        [Display(Name = "Group Description")]
        public string GroupDescription { get; set; }

    }
}
