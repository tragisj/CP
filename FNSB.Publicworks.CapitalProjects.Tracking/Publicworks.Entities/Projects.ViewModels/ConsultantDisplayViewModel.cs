using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicworks.Entities.Projects.ViewModels
{
    public class ConsultantDisplayViewModel
    {

        [Display(Name = "Customer Number")]
        public Guid CustomerID { get; set; }

        [Display(Name = "Consultant Name")]
        public string ConsultantName { get; set; }

        [Display(Name = "Consultant Description")]
        public string Description { get; set; }
    }
}
