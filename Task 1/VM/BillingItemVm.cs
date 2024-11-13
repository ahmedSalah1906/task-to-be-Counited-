using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using Task_1.Models;

namespace Task_1.VM
{
    public class BillingItemVm
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public decimal Price { get; set; }
        public int? BillingId { get; set; }
        public int? Quntity { get; set; } = 1;
        public List<SelectListItem> Items { get; set; } = new List<SelectListItem>();
    }
}
