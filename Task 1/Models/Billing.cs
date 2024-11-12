using System.ComponentModel.DataAnnotations.Schema;

namespace Task_1.Models
{
    public class Billing
    {
        public int Id { get; set; }
        public decimal TotelPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public List<BillItems> Items { get; set; }


    }
}
