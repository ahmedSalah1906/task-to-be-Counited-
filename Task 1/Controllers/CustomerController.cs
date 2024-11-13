using Microsoft.AspNetCore.Mvc;
using Task_1.Service.Customers;

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
            return View("AllCustomer");
        }
    }
}
