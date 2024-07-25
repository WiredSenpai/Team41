using Group41_Wired_Martians.Areas.Identity.Data;
using Group41_Wired_Martians.Models;
using Group41_Wired_Martians.viewmodels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Drawing;
using Microsoft.Extensions.Logging;

namespace Group41_Wired_Martians.Controllers
{
    public class FridgeAllocationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<FridgeAllocationController> _logger;

        public FridgeAllocationController(AppDbContext context, ILogger<FridgeAllocationController> logger)
        {
            _context = context;
            _logger = logger;

        }
        public async Task<IActionResult> Index()
        {
            var Allocations = await _context.FridgeAllocations.Include(c => c.Customer).Include("PurchaseItems.Inventory.Product").Include("PurchaseItems.ProductColors").
              ToListAsync();
            return View(Allocations);
        }
        public JsonResult GetProductColors(int productId)
        {
            var productColors = _context.ProductColors
                                        .Where(pc => pc.InventoryID == productId)
                                        .Select(pc => new
                                        {
                                            Value = pc.ColorID,
                                            Text = $"{pc.ColorName} - Qty: {pc.Qty}"
                                        })
                                        .ToList();

            return Json(productColors);
        }

        [HttpGet]
        public async Task<ActionResult> Create(int? id)
        {
            var viewModel = new FridgeAllocationViewModel()
            {
                Customers = await _context.Customers.ToListAsync(),
                Inventory = await _context.Inventories.Include(i => i.Product).ToListAsync(),
                ProductColors = await _context.ProductColors.ToListAsync(),
                PurchaseItem = new List<PurchaseItem>()
            };

            if (id.HasValue)
            {
                viewModel.FridgeAllocation = await _context.FridgeAllocations
                   .Include(i => i.PurchaseItems)
                   .FirstOrDefaultAsync(i => i.AllocationID == id);

                if (viewModel.FridgeAllocation == null)
                {
                    return NotFound();
                }
                viewModel.Customers = await _context.Customers.ToListAsync();
                viewModel.Inventory = await _context.Inventories.Include(i => i.Product).ToListAsync();
                viewModel.ProductColors = await _context.ProductColors.ToListAsync();
                viewModel.PurchaseItem = await _context.PurchaseItems.ToListAsync();

            }
            ViewBag.Customers = viewModel.Customers;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FridgeAllocationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    foreach (var key in Request.Form.Keys)
                    {
                        var value = Request.Form[key];

                        _logger.LogInformation($"Form Input - Key: {key}, Value: {value}");
                    }


                    var today = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                    var fridgeAllocation = new FridgeAllocation
                    {
                        CustomerID = viewModel.Customers.First().CustomerID,
                        AllocationStatus = "On Progress",
                        AllocationDate = today

                    };

                    if (fridgeAllocation.AllocationID == 0)
                    {
                        _context.FridgeAllocations.Add(fridgeAllocation);
                    }
                    else
                    {
                        _context.FridgeAllocations.Update(fridgeAllocation);
                    }

                    await _context.SaveChangesAsync();

                    foreach (var purchaseItem in viewModel.PurchaseItem)
                    {

                        if (purchaseItem.ItemID == 0)
                        {
                            purchaseItem.AllocationID = viewModel.FridgeAllocation.AllocationID;
                            _context.PurchaseItems.Add(purchaseItem);
                        }
                        else
                        {
                            _context.PurchaseItems.Update(purchaseItem);
                        }

                    }

                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Allocation  Made successfully." });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing the create action.");
                    ModelState.AddModelError("", "An error occurred while saving data: " + ex.Message);
                }

                viewModel.Customers = await _context.Customers.ToListAsync();
                viewModel.Inventory = await _context.Inventories.Include(i => i.Product).ToListAsync();
                viewModel.ProductColors = await _context.ProductColors.ToListAsync();
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return Json(new { success = false, errors });
        }
    }
}
