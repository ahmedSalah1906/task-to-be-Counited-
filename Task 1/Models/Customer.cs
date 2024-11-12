using System.ComponentModel;

namespace Task_1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<Billing> billings { get; set; }
    }
}
