using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnfallVisualisierung.Model
{
    public class AccidentStateDay
    {
        public DateTime Day { get; set; }
        public int TotalCount { get; set; }
        public int SeverityLevel1 { get; set; }
        public int SeverityLevel2 { get; set; }
        public int SeverityLevel3 { get; set; }
        public int SeverityLevel4 { get; set; }
    }
}
