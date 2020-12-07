using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ImportData
{
    public class DbContext
    {


        public async Task<IDbConnection> GetConnection()
        {
            try
            {
                var con = new MySqlConnection("");
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
