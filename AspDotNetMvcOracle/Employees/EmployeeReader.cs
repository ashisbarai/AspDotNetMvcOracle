using System.Collections.Generic;
using System.Threading.Tasks;
using AspDotNetMvcOracle.DataAccess;

namespace AspDotNetMvcOracle.Employees
{
    public class EmployeeReader
    {
        private readonly IDatabase _database;

        public EmployeeReader(IDatabase database)
        {
            _database = database;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            string sql = "SELECT NAME,DEPARTMENT FROM EMPLOYEE";
            return await _database.QueryAsync<Employee>(sql);
        }
    }
}