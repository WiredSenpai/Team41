using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group41_Wired_Martians.Areas.Identity.Data;
using Group41_Wired_Martians.Models;
using Newtonsoft.Json;

namespace Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;

        }
  
        public async Task<IActionResult> Index()
        {
            var Categ = _context.Categories;
            return View(await Categ.ToListAsync());
        }
        public async Task<ActionResult> AddandEdit(int? id)
        {
            if (id == null)
            {
                return View(new Category());
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddandEdit(int id, [Bind("CategoryID,CategoryName,Description,ImageURL", "CreatedDate", "ModifiedDate", "Status")] Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == 0)
                    {
                        _context.Add(category);

                    }
                    else
                    {
                        _context.Update(category);
                    }

                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Category saved successfully." });
                }
                catch (Exception )
                {
                    // Set error message
                    TempData["ErrorMessage"] = "An error occurred while saving the category.";
                }

            }
            else
            {
                // Set failure message
                TempData["FailureMessage"] = "Failed to add or update category. Please correct the errors and try again.";
            }
            return Json(new { success = false, message = "Failed to save Category." });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                category.Status = "Inactive";
                _context.Update(category);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(Index));
        }

    }
}
