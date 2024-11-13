using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task_1.Models;
using Task_1.Service.Bills;
using Task_1.Service.Customers;
using Task_1.Service.Employees;
using Task_1.Service.Items;
using Task_1.VM;

namespace Task_1.Controllers
{
    public class BillingController : Controller
    {
        IEmployeeService employeeService;
        IItemService itemService;
        ICustomerService customerService;
        IBillingService billingService;
        public BillingController(IEmployeeService employeeService
            ,IItemService itemService,
            ICustomerService customerService,
            IBillingService billingService) 
        {
            this.employeeService = employeeService;
            this.itemService = itemService;
            this.customerService = customerService;
            this.billingService = billingService;
        }
        public IActionResult Index()
        {
            var AllBills = billingService.GetAll();

            
            return View("AllBills", AllBills);
        }
        public IActionResult Create()
        {
            var model = new BillingVm
            {
                EmployeesList = employeeService.GetAll().Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToList(),
                CustomerList = customerService.GetAll().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList(),
                ItemsList = itemService.GetAll().Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToList()
            };

            return View("CreateBill",model);
        }
        [HttpPost]
        public IActionResult Create([FromForm] BillingVm vm)
        {
            if (!ModelState.IsValid)
            {
                vm.EmployeesList = employeeService.GetAll().Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name }).ToList();
                vm.CustomerList = customerService.GetAll().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                vm.ItemsList = itemService.GetAll().Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToList();

                return View("CreateBill", vm);
            }
            else
            {
                billingService.Create(vm);
                return RedirectToAction("Index");
            }


        }

        [HttpGet]
        public IActionResult RenderItemPartial(int index)
        {
            var model = new BillingItemVm
            {
                Id = index,
                Items = itemService.GetAll().Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToList()
            };

            return PartialView("_ItemPartial", model);
        }


    }
}
