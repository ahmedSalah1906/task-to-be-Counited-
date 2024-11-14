using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Task_1.Models;

namespace Task_1.Repository.Employees
{
    public class EmployeeRepository:IEmployeeRepositry
    {
        BillingContext billingContext;
        public EmployeeRepository(BillingContext billingContext)
        {
            this.billingContext = billingContext;
        }

        public Employee Create(Employee entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var entry= billingContext.Employees.Add(entity);
            Save();
            return entry.Entity;
           
        }

        public void DeleteById(int id)
        {
           var emp =GetById(id);
            if (emp != null) 
            {
                billingContext.Employees.Remove(emp);
                Save ();    
            }
           
        }

        public List<Employee> GetAll()
        {
            var emps = billingContext.Employees.AsNoTracking().ToList();
            if (emps!=null) 
            {
                return emps;
            }
            return null;
        }

        public Employee GetById(int id)
        {
            var emp = billingContext.Employees.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                return emp;
            }
            return null;

        }

        public Employee Update(Employee entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var entry = billingContext.Employees.Update(entity);
            Save();
            return entry.Entity;
        }
        public void Save()
        {
            billingContext.SaveChanges();
        }
    }
}
