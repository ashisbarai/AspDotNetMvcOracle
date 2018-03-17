using System.Threading.Tasks;
using AspDotNetMvcOracle.DataAccess;
using AspDotNetMvcOracle.Models;

namespace AspDotNetMvcOracle.Employees
{
    public class EmployeeCreator
    {
        private readonly IDatabase _database;

        public EmployeeCreator(IDatabase database)
        {
            _database = database;
        }
        public async Task CreateAsync(EmployeeModel employee)
        {
            string sql = $"INSERT INTO EMPLOYEE(NAME,DEPARTMENT)VALUES('{employee.Name}','{employee.Department}')";
            await _database.OperationalAsync(sql);
        }
    }
}