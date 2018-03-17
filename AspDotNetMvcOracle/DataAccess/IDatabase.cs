using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspDotNetMvcOracle.DataAccess
{
    public interface IDatabase : IDisposable
    {
        Task OperationalAsync(string sql);
        Task<int> ExecuteAsync(string sql, object param = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);
    }
}