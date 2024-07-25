using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group41_Wired_Martians.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
      
        
        [ForeignKey("ProductID")]
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public int? StockQuantity { get; set; }

        public int? Availability { get; set; }
        public string? Location { get; set; }
        public string? Brand { get; set; }
        public int? Damaged { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public ICollection<ProductColors>? ProductColors { get; set; } = new List<ProductColors>();
 
    }
}
