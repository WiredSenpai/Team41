using Group41_Wired_Martians.Areas.Identity.Data;
using Group41_Wired_Martians.Models;
using Group41_Wired_Martians.viewmodels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Group41_Wired_Martians.Controllers
{
    public class StockLiasonController : Controller
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public StockLiasonController(AppDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> DashBoard()
        {
      

            var inventories = await _context.Inventories
        .Include(i => i.Product)
        .Include(i => i.ProductColors)
        .ToListAsync();

            var products = await _context.Products.Include(c => c.Category).Include(s => s.Supplier).ToListAsync();

            var productscount = await _context.Products.CountAsync();
            ViewBag.Productscount = productscount;

            var customers = await _context.Customers
                .OrderByDescending(c => c.CustomerID)
                .ToListAsync();

            var activeemployees = await _context.Customers.Where(c => c.Status == "Active").CountAsync();

            ViewBag.ActiveCustomerCount = activeemployees;

            var viewModel = new DashboardViewmodel
            {
                Inventories = inventories,
                Customers = customers,
                Products = products,
               
            };

            return View(viewModel);
        }

    }
}
