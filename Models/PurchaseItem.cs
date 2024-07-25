
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group41_Wired_Martians.Models
{
    public class PurchaseItem
    {
        [Key]
        public int ItemID { get; set; }
        public int? AllocationID { get; set; }
        [ForeignKey("AllocationID")]
        public FridgeAllocation? Allocation { get; set; }
        [ForeignKey("InventoryID")]
        public int? InventoryID { get; set; }
        public Inventory? Inventory { get; set; }

        [ForeignKey("ColorID")]
        public int? ColorID { get; set; }

        public ProductColors? ProductColors { get; set; }
        public int? Quantity { get; set; }
    }
}
