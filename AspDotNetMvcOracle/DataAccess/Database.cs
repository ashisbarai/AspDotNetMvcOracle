using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace AspDotNetMvcOracle.DataAccess
{
    public class Database : IDatabase
    {
        private static OracleConnection Connection =>
            new OracleConnection(ConfigurationManager.ConnectionStrings["aspDotNetMvcOracleContext"].ConnectionString);
        public void Dispose()
        {

        }
        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            using (var connection = Connection)
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(sql, param);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            using (var connection = Connection)
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<T>(sql, param);
            }
        }

        public async Task OperationalAsync(string sql)
        {
            using (var connection = Connection)
            {
                using (var command = new OracleCommand(sql, connection))
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}