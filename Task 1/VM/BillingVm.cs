using Microsoft.AspNetCore.Mvc.Rendering;
using Task_1.Models;

namespace Task_1.VM
{
    public class BillingVm
    {
        public int Id { get; set; }
        public decimal TotelPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
      
        public List<SelectListItem>? EmployeesList { get; set; }
        public List<SelectListItem>? CustomerList { get; set; }
        public List<SelectListItem>? ItemsList { get; set; }

     
        public List<BillingItemVm> Items { get; set; } = new List<BillingItemVm>();

    }
}
