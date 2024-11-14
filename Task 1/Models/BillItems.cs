using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.Marshalling;

namespace Task_1.Models
{
    public class BillItems
    {
        public int Id { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item item { get; set; }
        public virtual Billing billing { get; set; }
        [ForeignKey("Billing")]
        public int BillingId { get; set; }
        public int Quntity { get; set; } = 0;

    }
}
