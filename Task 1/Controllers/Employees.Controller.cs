using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Task_1.Service.Employees;
using Task_1.VM;

namespace Task_1.Controllers
{
    public class Employees : Controller
    {
        IEmployeeService employeeService;
        public Employees(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var AllEmps = employeeService.GetAll();

            return View("AllEmps", AllEmps);
        }
        public IActionResult Create()
        {
            var Emp = new EmployeeVm();

            return View("Create", Emp);
        }

        [HttpPost]
        public IActionResult Create([FromForm] EmployeeVm emp)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", emp);
            }
            else
            {
                employeeService.Create(emp);
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public IActionResult Update(int id)
        {

            var emp = employeeService.GetById(id);
            if (emp != null)
            {
                return View("Edit", emp);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update([FromForm] EmployeeVm emp)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", emp);
            }
            else
            {
                employeeService.Update(emp);
                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id)
        {
            var emp = employeeService.GetById(id);
            if (emp != null)
            {
                employeeService.Delete(id);
                return  RedirectToAction("Index");
            }
            return NotFound();


        }
    }
}
