using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnfallVisualisierung.Model
{
    public class AccidentState
    {
        public string State { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public List<AccidentStateDay> AccidentEvents { get; set; }
    }
}
