using Task_1.Models;

namespace Task_1.VM
{
    public class BillingVm
    {
        public decimal TotelPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        
        public List<BillItems> Items {  get; set; }

    }
}
