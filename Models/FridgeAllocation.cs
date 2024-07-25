using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group41_Wired_Martians.Models
{
    public class FridgeAllocation
    {
        [Key]
        public int AllocationID { get; set; }
        [ForeignKey("CustomerID")]
        public int? CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public string? AllocationStatus { get; set; }
        public DateOnly? AllocationDate { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    }
}
