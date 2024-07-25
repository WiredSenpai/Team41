using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group41_Wired_Martians.Models
{
    public class ProductColors
    {
        [Key]
        public int ColorID { get; set; }
        public int? InventoryID { get; set; }
        [ForeignKey("InventoryID")]
        public  Inventory? Inventory { get; set; }
        public string? ColorName { get; set; }
        public string? Img { get; set; }
        public string? Qty { get; set; }
     
    }
}
