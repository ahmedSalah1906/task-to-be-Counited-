using Microsoft.AspNetCore.Mvc;
using Task_1.Service.Customers;
using Task_1.VM;

namespace Task_1.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        public IActionResult Index()
        {
            var AllCustomer = customerService.GetAll();
            return View("AllCustomer", AllCustomer);
        }
        public IActionResult Create()
        {
            var Customer = new CustomerVm();

            return View("CreateCust", Customer);
        }
        [HttpPost]
        public IActionResult Create([FromForm] CustomerVm Customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateCust", Customer);
            }
            else
            {
                customerService.Create(Customer);
                return RedirectToAction("Index");
            }

        }
        public IActionResult Update(int id)
        {
            var Customer = customerService.GetById(id);
            if (Customer != null)
            {
                return View("EditCust", Customer);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update([FromForm] CustomerVm customer)
        {
            if (!ModelState.IsValid && customer != null)
            {
                return View("EditCust", customer);
            }
            else
            {
                customerService.Update(customer);
                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id) 
        {
            var customer = customerService.GetById(id);
            if (customer != null)
            {
                customerService.Delete(id);
                return RedirectToAction("Index");
            }
            return NotFound(" the customer you trying to delete is already not exasist");
        }
    }
}
