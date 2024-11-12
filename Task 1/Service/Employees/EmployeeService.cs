using Task_1.Models;
using Task_1.Repository.Employees;
using Task_1.VM;

namespace Task_1.Service.Employees
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepositry Repo;
        public EmployeeService(IEmployeeRepositry Repo ) 
        {
            this.Repo = Repo;
        }

        public void Create(EmployeeVm entity)
        {
           if ( entity == null ) throw new ArgumentNullException(nameof(entity));
            var employee = new Employee()
            {
                age=entity.age,
                Name=entity.Name,

            };

            Repo.Create(employee);

        }

        public void Delete(int id)
        {
           
            Repo.DeleteById(id);
        }

        public List<EmployeeVm> GetAll()
        {
           var employees = Repo.GetAll();
            var employeeVm=employees.Select(e => new EmployeeVm()
            {
                Id=e.Id,
                age=e.age,
                Name=e.Name,

            }).ToList();
            return employeeVm;
        }

        public EmployeeVm GetById(int id)
        {
            var emp =Repo.GetById(id);
            var empVme = new EmployeeVm()
            {
                Id=id,
                age = emp.age,
                Name = emp.Name,
            };
            return empVme;

        }

        public void Update(EmployeeVm entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var employee = new Employee()
            {
                Id = entity.Id,
                age = entity.age,
                Name = entity.Name,

            };

            Repo.Update(employee);

        }
    }
}
