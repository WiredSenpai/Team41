using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group41_Wired_Martians.Areas.Identity.Data;
using Group41_Wired_Martians.Models;
using Group41_Wired_Martians.viewmodels;
using Newtonsoft.Json;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly AppDbContext _context;

        public ProductController(IWebHostEnvironment hostEnvironment, AppDbContext context)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;

        }
      
        public async Task<IActionResult> ProductList()
        {
            var ProductList = _context.Products.Include(c => c.Category).Include(c => c.Supplier);
            return View(await ProductList.ToListAsync());


        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<ActionResult> AddandEdit(int? id)
        {
       
            var supplier = await _context.Suppliers.ToListAsync();
            ViewData["SupplierID"] = new SelectList(supplier, "SupplierID", "SupplierName");

            var categories = await _context.Categories.ToListAsync();
            ViewData["CategoryID"] = new SelectList(categories, "CategoryID", "CategoryName");

            if (id == null)
            {
                return View(new Product());
            }
            var product = await _context.Products
                                .FirstOrDefaultAsync(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", product.CategoryID);

            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            return View(product);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddandEdit(int id, Product product)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    if (product.ImageFile1 != null)
                    {
                        try
                        {
                            string wwwRootPath = _hostEnvironment.WebRootPath;
                            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile1.FileName);
                            string extension = Path.GetExtension(product.ImageFile1.FileName);
                            product.ImgThumbnail = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                            string path = Path.Combine(wwwRootPath + "/images/", fileName);
                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                await product.ImageFile1.CopyToAsync(fileStream);
                            }
                        }
                        catch (Exception ex)
                        {
                            TempData["ErrorMessage"] = "An error occurred while uploading the first image.";
                            Console.WriteLine($"Exception: {ex.Message}, StackTrace: {ex.StackTrace}");
                            return Json(new { success = false, message = "Failed to upload first image." });
                        }
                    }

                    if (product.ImageFile2 != null)
                    {
                        try
                        {
                            string wwwRootPath = _hostEnvironment.WebRootPath;
                            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile2.FileName);
                            string extension = Path.GetExtension(product.ImageFile2.FileName);
                            product.ImageFile = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                            string path = Path.Combine(wwwRootPath + "/images/", fileName);
                            using (var fileStream = new FileStream(path, FileMode.Create))
                            {
                                await product.ImageFile2.CopyToAsync(fileStream);
                            }
                        }
                        catch (Exception ex)
                        {
                            TempData["ErrorMessage"] = "An error occurred while uploading the second image.";
                            Console.WriteLine($"Exception: {ex.Message}, StackTrace: {ex.StackTrace}");
                            return Json(new { success = false, message = "Failed to upload second image." });
                        }
                    }


                    var existingProduct = await _context.Products
                   .FirstOrDefaultAsync(p => p.ProductID == id);

                    

                    if (existingProduct != null)
                    {
                        _context.Entry(existingProduct).CurrentValues.SetValues(product);
                        _context.Update(existingProduct);
                    }
                    else
                    {

                        _context.Add(product);
                    }

                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Product saved successfully." });

                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while saving the product.";
                    Console.WriteLine($"Exception: {ex.Message}, StackTrace: {ex.StackTrace}");
                }

            }
            else
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                       
                        Console.WriteLine($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
                    }
                }

                TempData["FailureMessage"] = "Failed to add or update product. Please correct the errors and try again.";
            }
            ViewData["CategoryID"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryID", "CategoryName", product.CategoryID);

            ViewData["SupplierID"] = new SelectList(await _context.Suppliers.ToListAsync(), "SupplierID", "SupplierName", product.SupplierID);

            return Json(new { success = false, message = "Failed to save product." });
        }

   
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.Status = "Inactive";
                _context.Update(product);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(ProductList));
        }
    }
}
