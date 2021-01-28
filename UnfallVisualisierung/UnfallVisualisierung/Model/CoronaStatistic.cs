using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnfallVisualisierung.Model
{
    public class CoronaStatistic
    {
        public string Province_State { get; set; }
        public DateTime Last_Update { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int? Recovered { get; set; }
        public int FIPS { get; set; }
        public double? Incident_Rate { get; set; }
        public int Total_Test_Result { get; set; }
    }
}
