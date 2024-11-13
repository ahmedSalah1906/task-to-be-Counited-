using Task_1.Models;
using Task_1.Repository.Items;
using Task_1.VM;

namespace Task_1.Service.Items
{
    public class ItemService: IItemService
    {
        IItemReopsitory Repo;
        public ItemService(IItemReopsitory Repo)
        {
            this.Repo = Repo;
        }
        public void Create(ItemVm entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var item
                = new Item()
            {
             
              Name = entity.Name,
               Price = entity.Price,
               Description = entity.Description,

            };

            Repo.Create(item);

        }

        public void Delete(int id)
        {

            Repo.DeleteById(id);
        }

        public List<ItemVm> GetAll()
        {
            var item = Repo.GetAll();
            var itemVm = item.Select(e => new ItemVm()
            {
                Id=e.Id,
                Description = e.Description,
                Name = e.Name,
                Price = e.Price,

            }).ToList();
            return itemVm;
        }

        public ItemVm GetById(int id)
        {
            var item = Repo.GetById(id);
            var itemVm = new ItemVm()
            {
                Id = id,
                Description= item.Description,
                Name = item.Name,
                Price = item.Price,
            };
            return itemVm;

        }

        public void Update(ItemVm entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var item = new Item()
            { 
             Id=entity.Id,
            Description = entity.Description,
            Name = entity.Name,
            Price = entity.Price,
            

            };

            Repo.Update(item);

        }
    }
}
