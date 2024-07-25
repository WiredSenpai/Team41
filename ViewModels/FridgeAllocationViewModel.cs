using Microsoft.AspNetCore.Mvc.Rendering;
using Group41_Wired_Martians.Models;
using System.ComponentModel.DataAnnotations;

namespace Group41_Wired_Martians.viewmodels
{
    public class FridgeAllocationViewModel
    {
        public FridgeAllocation? FridgeAllocation { get; set; }
        public List<Customer>? Customers { get; set; } =new List<Customer>();
        public List<PurchaseItem>? PurchaseItem { get; set; } = new List<PurchaseItem>();
        public List<Inventory>? Inventory { get; set; }= new List<Inventory>();
        public List<ProductColors>? ProductColors { get; set; }=new List<ProductColors>();
    }
}
