using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels.Funds
{
    public class KeyDetailViewModel
    {
        [Display(Name = "GL Key")]
        public string GLKey { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public string Budget { get; set; }
        public string Actual { get; set; }
        public string Encumbrances { get; set; }
        public string Balance { get; set; }

    }
}
