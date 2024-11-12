namespace Task_1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public List<Billing>? billings { get; set; }


    }
}
