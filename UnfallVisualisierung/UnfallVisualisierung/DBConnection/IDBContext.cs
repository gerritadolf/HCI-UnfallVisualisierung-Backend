using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace UnfallVisualisierung.DBConnection
{
    public interface IDBContext
    {
        public Task<IDbConnection> GetConnection();
    }
}
