using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWTrackingReporting.UI
{
    class TrackingGridDisplay
    {
        public Object Icon { get; set; }
        public Int32 Recordid { get; set; }
        public String ProjectName { get; set; }
        public String ProjectNumber { get; set; }
        public DateTime? ActiveDate { get; set; }
        public String ProjectStatus { get; set; }
    }
}
