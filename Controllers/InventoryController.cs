using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group41_Wired_Martians.Areas.Identity.Data;
using Group41_Wired_Martians.viewmodels;
using Newtonsoft.Json;

namespace Group41_Wired_Martians.Controllers
{
    public class InventoryController : Controller
    {
        private readonly AppDbContext _context;

        public InventoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> InventoryList()
        {
            var inventories = await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.ProductColors)
                .ToListAsync();

            return View(inventories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var inventory = await _context.Inventories
                .Include(i => i.Product)
                .Include(i => i.ProductColors)
                .FirstOrDefaultAsync(i => i.InventoryID == id);

            if (inventory == null)
            {
                return NotFound();
            }

            return PartialView("_InventoryDetailsPartial", inventory);
        }


        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            var viewModel = new InventoryProductColorViewModel
            {
                Products = await _context.Products.ToListAsync()
            };

            if (id.HasValue)
            {
                viewModel.Inventory = await _context.Inventories
                   .Include(i => i.ProductColors)
                   .FirstOrDefaultAsync(i => i.InventoryID == id);

                if (viewModel.Inventory == null)
                {
                    return NotFound();
                }
                viewModel.ProductColors = viewModel.Inventory.ProductColors.ToList();
                viewModel.SelectedProductId = viewModel.Inventory.ProductID;
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryProductColorViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        model.Inventory.ProductID = model.SelectedProductId;


                        // Calculate StockQuantity based on ProductColors quantities
                        int totalStockQuantity = model.ProductColors.Sum(pc => int.TryParse(pc.Qty, out int qty) ? qty : 0);
                        model.Inventory.StockQuantity = totalStockQuantity;

                        // Calculate Availability (StockQuantity - Damaged)
                        model.Inventory.Availability = model.Inventory.StockQuantity - (model.Inventory.Damaged ?? 0);

                        if (model.Inventory.InventoryID == 0)
                        {
                            _context.Inventories.Add(model.Inventory);
                        }
                        else
                        {
                            _context.Inventories.Update(model.Inventory);
                        }

                        await _context.SaveChangesAsync();

                        // Add or update ProductColors
                        foreach (var color in model.ProductColors)
                        {
                            if (color.ColorID == 0)
                            {
                                color.InventoryID = model.Inventory.InventoryID;
                                _context.ProductColors.Add(color);
                            }
                            else
                            {
                                _context.ProductColors.Update(color);
                            }
                        }

                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();

                        return Json(new { success = true, message = "Inventory saved successfully." });
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        ModelState.AddModelError("", "An error occurred while saving data: " + ex.Message);
                    }
                }
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return Json(new { success = false, errors });
        }

        [HttpGet]
        public async Task<IActionResult> GetProductBrand(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            return Json(new { brand = product.Brand });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Inventories
                .FirstOrDefaultAsync(m => m.InventoryID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(InventoryList));
        }
    }
}
