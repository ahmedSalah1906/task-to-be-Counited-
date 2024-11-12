using Task_1.Models;

namespace Task_1.Repository.Items
{
    public class ItemRepository:IItemReopsitory
    {
        BillingContext billingContext;
        public ItemRepository(BillingContext billingContext)
        {
            this.billingContext = billingContext;

        }

        public Item Create(Item entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var entry = billingContext.Items.Add(entity);
            Save();
            return entry.Entity;

        }

        public void DeleteById(int id)
        {
            var emp = GetById(id);
            if (emp != null)
            {
                billingContext.Items.Remove(emp);
                Save();
            }

        }

        public List<Item> GetAll()
        {
            var emps = billingContext.Items.ToList();
            if (emps != null)
            {
                return emps;
            }
            return null;
        }

        public Item GetById(int id)
        {
            var emp = billingContext.Items.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                return emp;
            }
            return null;

        }

        public Item Update(Item entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var entry = billingContext.Items.Update(entity);
            Save();
            return entry.Entity;
        }
        public void Save()
        {
            billingContext.SaveChanges();
        }
    }
}
