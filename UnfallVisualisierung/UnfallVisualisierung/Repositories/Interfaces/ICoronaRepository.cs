using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnfallVisualisierung.Model;

namespace UnfallVisualisierung.Repositories.Interfaces
{
    public interface ICoronaRepository
    {
        public Task<IEnumerable<CoronaStatistic>> GetCoronaStatistic();
        public Task<CoronaStatistic> GetCoronaStatisticByState(string state);
    }
}
