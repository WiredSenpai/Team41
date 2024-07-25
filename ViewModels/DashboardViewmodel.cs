using Group41_Wired_Martians.Models;

namespace Group41_Wired_Martians.viewmodels
{
    public class DashboardViewmodel
    {
        public IEnumerable<Inventory>? Inventories { get; set; }
        public IEnumerable<Customer>? Customers { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<FridgeAllocation>? FridgeAllocations { get; set; }
    }
}
