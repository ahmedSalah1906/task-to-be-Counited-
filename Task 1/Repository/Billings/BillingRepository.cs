using Microsoft.EntityFrameworkCore;
using Task_1.Models;

namespace Task_1.Repository.Billings
{
    public class BillingRepository:IBillingRepository
    {
        BillingContext billingContext;
        public BillingRepository(BillingContext billingContext)
        {
            this.billingContext = billingContext;
        }
        public Billing Create(Billing entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var entry = billingContext.Billing.Add(entity);
            Save();
            return entry.Entity;

        }

        public void DeleteById(int id)
        {
            var emp = GetById(id);
            if (emp != null)
            {
                billingContext.Billing.Remove(emp);
                Save();
            }

        }

        public List<Billing> GetAll()
        {
            var emps = billingContext.Billing.Include(i=>i.Items).Include(b=>b.Customer).Include(e=>e.Employee).ToList();
            if (emps != null)
            {
                return emps;
            }
            return null;
        }

        public Billing GetById(int id)
        {
            var emp = billingContext.Billing.Include(i => i.Items).Include(b => b.Customer).Include(e => e.Employee).FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                return emp;
            }
            return null;

        }

        public Billing  Update(Billing entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var entry = billingContext.Billing.Update(entity);
            Save();
            return entry.Entity;
        }
        public void Save()
        {
            billingContext.SaveChanges();
        }
    }
}
