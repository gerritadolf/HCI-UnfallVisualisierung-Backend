using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnfallVisualisierung.DBConnection;
using UnfallVisualisierung.Model;
using UnfallVisualisierung.Repositories.Interfaces;

namespace UnfallVisualisierung.Repositories
{
    public class CoronaRepository : ICoronaRepository
    {
        private readonly IDBContext _dbContext;
        private readonly ILogger<CoronaRepository> _logger;

        public CoronaRepository(IDBContext dbContext, ILogger<CoronaRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

		public async Task<IEnumerable<CoronaStatistic>> GetCoronaStatistic()
		{
            var query = "SELECT * FROM CoronaStatistic";

            try
            {
                using (var con = await _dbContext.GetConnection())
                {
                    var result = con.Query<CoronaStatistic>(query);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("SQL Connection and Query failed!", ex);
                return null;
            }
        }

		public async Task<CoronaStatistic> GetCoronaStatisticByState(string state)
        {
            var query = "SELECT * FROM CoronaStatistic WHERE Province_State = @state";
            var param = new DynamicParameters();
            param.Add("@state", state);

            try
            {
                using(var con = await _dbContext.GetConnection())
                {
                    var result = con.QueryFirstOrDefault<CoronaStatistic>(query, param);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("SQL Connection and Query failed!", ex);
                return null;
            }
        }
    }
}
