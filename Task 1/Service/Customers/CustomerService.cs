using Task_1.Models;
using Task_1.Repository.Customers;
using Task_1.VM;

namespace Task_1.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository Repo;
        public CustomerService(ICustomerRepository Repo)
        {
            this.Repo = Repo;
        }
        public void Create(CustomerVm entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var customer = new Customer()
            {
                Address = entity.Address,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
            };

            Repo.Create(customer);

        }

        public void Delete(int id)
        {

            Repo.DeleteById(id);
        }

        public List<CustomerVm> GetAll()
        {
            var customers = Repo.GetAll();
            var CustmVm = customers.Select(e => new CustomerVm()
            {Id = e.Id,
                Address=e.Address,
                Name=e.Name,
                PhoneNumber=e.PhoneNumber,
            }).ToList();
            return CustmVm;
        }

        public CustomerVm GetById(int id)
        {
            var cust = Repo.GetById(id);
            var CustmVm = new CustomerVm()
            {
                Id = cust.Id,
             Address=cust.Address,
             Name=cust.Name,
             PhoneNumber=cust.PhoneNumber,

            };
            return CustmVm;

        }

        public void Update(CustomerVm entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var Cust = new Customer()
            {
                   Id=entity.Id,
                   Address=entity.Address,
                   Name=entity.Name,
                   PhoneNumber=entity.PhoneNumber,


            };

            Repo.Update(Cust);

        }

    }
}
