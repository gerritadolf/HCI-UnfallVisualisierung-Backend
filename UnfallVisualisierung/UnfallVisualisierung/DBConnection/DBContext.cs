using Microsoft.Extensions.Options;
using MySqlConnector;
using System;
using System.Data;
using System.Threading.Tasks;

namespace UnfallVisualisierung.DBConnection
{
    public class DBContext : IDBContext
    {
        private readonly DBConnection _options;
        public DBContext(IOptions<DBConnection> options) {
            _options = options.Value;
        }
        public async Task<IDbConnection> GetConnection()
        {
            try
            {
                var con = new MySqlConnection(_options.ConnectionString);
                await con.OpenAsync();
                return con;
            }
            catch (MySqlException e)
            {
                Console.Write(e.ToString());
                return null;
            }
        }
    }
}
