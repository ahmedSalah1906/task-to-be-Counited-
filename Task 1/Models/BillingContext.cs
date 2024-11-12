using Microsoft.EntityFrameworkCore;

namespace Task_1.Models
{
    public class BillingContext:DbContext
    {
        public BillingContext(DbContextOptions<BillingContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Billing> Billing { get; set; }
        public DbSet<BillItems> BillItems { get; set; } 
        public DbSet<Customer> Customer { get; set; }   

        public DbSet<Item> Items { get; set; }  
    }
}
