using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using AspDotNetMvcOracle.Employees;
using AspDotNetMvcOracle.Models;

namespace AspDotNetMvcOracle.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeeReader _employeeReader;
        private readonly EmployeeCreator _employeeCreator;

        public HomeController(EmployeeReader employeeReader, EmployeeCreator employeeCreator)
        {
            _employeeReader = employeeReader;
            _employeeCreator = employeeCreator;
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home";
            var emps = await _employeeReader.GetEmployeesAsync();
            ViewBag.Employees = emps;
            return View();
        }

        public ActionResult AddEmployee()
        {
            ViewBag.Title = "Add Employee";
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddEmployee");
            }
            await _employeeCreator.CreateAsync(model);
            return RedirectToAction("Index");
        }
    }
}