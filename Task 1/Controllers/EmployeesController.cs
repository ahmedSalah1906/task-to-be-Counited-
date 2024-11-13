using Microsoft.AspNetCore.Mvc;
using Task_1.Service.Employees;

namespace Task_1.Controllers
{
    public class EmployeesController : Controller
    {
        IEmployeeService employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var AllEmps= employeeService.GetAll();
            return View("AllEmps",AllEmps);
        }
    }
}
