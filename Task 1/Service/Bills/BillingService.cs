using Task_1.Models;
using Task_1.Repository.Billings;
using Task_1.VM;

namespace Task_1.Service.Bills
{
    public class BillingService:IBillingService
    {
        IBillingRepository Repo;
        public BillingService(IBillingRepository Repo)
        {
            this.Repo = Repo;
        }

        public void Create(BillingVm entity)
        {
            var Bill = new Billing()
            {
                CreatedAt = DateTime.Now,
                CustomerId = entity.CustomerId,
                EmployeeId = entity.EmployeeId,
                TotelPrice = entity.TotelPrice,
       
                Items = entity.Items.Select(x => new BillItems
                {
                    ItemId = x.ItemId,
                    Quntity = x.Quntity,
                    BillingId = x.BillingId,
                }).ToList(),
                

            };
            Repo.Create(Bill);
        }

        public void Delete(int id)
        {
            Repo.DeleteById(id);

            
        }

        public List<BillingVm> GetAll()
        {
            var Bills = Repo.GetAll();
            var BillVm = Bills.Select(x => new BillingVm
            {
                CreatedAt = DateTime.Now,
                CustomerName = x.Customer.Name,
                EmployeeName = x.Employee.Name,
                CustomerId = x.Customer.Id,
                EmployeeId = x.Employee.Id,
                TotelPrice = x.TotelPrice,
                Items = x.Items.Select(i => new BillItems
                {
                    Quntity=i.Quntity,
                    ItemId = i.ItemId,
                    BillingId = i.BillingId,



                }).ToList(),

            }).ToList();
            return BillVm;
            

            
        }

        public BillingVm GetById(int id)
        {
            var Bill = Repo.GetById(id);
            var billvm = new BillingVm
            {
                CreatedAt = DateTime.Now,
                CustomerId = Bill.Customer.Id,
                CustomerName = Bill.Customer.Name,
                EmployeeId = Bill.Employee.Id,
                EmployeeName = Bill.Employee.Name,
                Items = Bill.Items.Select(i => new BillItems
                {
                    Quntity = i.Quntity,
                    ItemId = i.ItemId,
                    BillingId = i.BillingId,

                }).ToList(),
            };
            return billvm;
        }

        public void Update(BillingVm entity)
        {
            var Bill = new Billing()
            {
                CreatedAt = DateTime.Now,
                CustomerId = entity.CustomerId,
                EmployeeId = entity.EmployeeId,
                TotelPrice = entity.TotelPrice,

                Items = entity.Items.Select(x => new BillItems
                {
                    ItemId = x.ItemId,
                    Quntity = x.Quntity,
                    BillingId = x.BillingId,
                }).ToList(),


            };
            Repo.Update(Bill);
        }
    }
}
