using Microsoft.AspNetCore.Mvc;
using Task_1.Models;
using Task_1.Service.Items;
using Task_1.VM;

namespace Task_1.Controllers
{
    public class ItemsController : Controller
    {
        IItemService itemService;
        public ItemsController(IItemService itemService) 
        {
            this.itemService = itemService;
        }
        public IActionResult Index()
        {
            var AllItems= itemService.GetAll();
            return View("AllItems" ,AllItems);
        }
        public IActionResult Create()
        {
            var Item=  new ItemVm();
            return View("CreateItem",Item);
        }
        [HttpPost]
        public IActionResult Create([FromForm] ItemVm item)
        {
            if (!ModelState.IsValid) 
            {
                return View("CreateItem", item);
            }
            else
            {
                itemService.Create(item);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = itemService.GetById(id);
            if (item != null)
            {
                return View("EditItem", item);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update([FromForm] ItemVm item)
        {
            if (!ModelState.IsValid)
            {
                return View("EditItem", item);
            }
            itemService.Update(item);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var item = itemService.GetById(id);
            if (item != null)
            {
                itemService.Delete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }


    }
}
