using Task_1.Models;

namespace Task_1.Repository.Customers
{
    public class CustomerRepository:ICustomerRepository
    {
        BillingContext billingContext;
        public CustomerRepository(BillingContext billingContext)
        {
            this.billingContext = billingContext;
        }
        public Customer Create(Customer entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var entry = billingContext.Customer.Add(entity);
            Save();
            return entry.Entity;

        }

        public void DeleteById(int id)
        {
            var emp = GetById(id);
            if (emp != null)
            {
                billingContext.Customer.Remove(emp);
                Save();
            }

        }

        public List<Customer> GetAll()
        {
            var emps = billingContext.Customer.ToList();
            if (emps != null)
            {
                return emps;
            }
            return null;
        }

        public Customer GetById(int id)
        {
            var emp = billingContext.Customer.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                return emp;
            }
            return null;

        }

        public Customer Update(Customer entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var entry = billingContext.Customer.Update(entity);
            Save();
            return entry.Entity;
        }
        public void Save()
        {
            billingContext.SaveChanges();
        }
    }
}
