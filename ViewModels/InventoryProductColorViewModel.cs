using Group41_Wired_Martians.Models;
using System.ComponentModel.DataAnnotations;

namespace Group41_Wired_Martians.viewmodels
{
	public class InventoryProductColorViewModel
	{
        public Inventory? Inventory { get; set; }
        public List<ProductColors>? ProductColors { get; set; } = new List<ProductColors>();

        public List<Product>? Products { get; set; } = new List<Product>();
        public int? SelectedProductId { get; set; }
    }
}
