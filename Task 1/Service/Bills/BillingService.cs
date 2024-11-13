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
                    Id = x.Id,
                    Quntity = (int)x.Quntity,
                    item=new Item { Price = x.Price},
                    BillingId = (int)x.BillingId,
                    ItemId = (int)x.ItemId,
                    
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
                CreatedAt = x.CreatedAt,
                CustomerId = x.Customer?.Id ?? 0,  
                EmployeeId = x.Employee?.Id ?? 0,
                Id = x.Id,
                TotelPrice = x.TotelPrice,

                Items = x.Items
                    .Where(i => i != null && i.item != null)  
                    .Select(i => new BillingItemVm
                    {
                        Quntity = i.Quntity,
                        ItemId = i.ItemId,
                        BillingId = i.BillingId,
                        Price = i.item?.Price ?? 0,  
                        Id = i.Id,
                    })
                    .ToList(),
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
                TotelPrice= Bill.TotelPrice,
                
                EmployeeId = Bill.Employee.Id,

                Items = Bill.Items.Select(i => new BillingItemVm
                {
                    Quntity = i.Quntity,
                    ItemId = i.ItemId,
                    BillingId = i.BillingId,
                    Price=i.item.Price,
                    Id = i.Id,
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
                    ItemId = (int)x.ItemId,
                    Quntity = (int)x.Quntity,
                    BillingId =(int) x.BillingId,
                    item=new Item { Price=x.Price},
                    Id = x.Id,
                }).ToList(),


            };
            Repo.Update(Bill);
        }
    }
}
