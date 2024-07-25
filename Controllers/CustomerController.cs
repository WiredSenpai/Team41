using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Group41_Wired_Martians.Areas.Identity.Data;
using Group41_Wired_Martians.Models;

namespace Group41_Wired_Martians.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> AllCustomers()
        {
            var Customer = _context.Customers;
            return View(await Customer.ToListAsync());


        }
        public async Task<ActionResult> CreateCustomer(int? id)
        {
            if (id == null)
            {
                return View(new Customer());
            }
            var Customers = await _context.Customers.FindAsync(id);
            if (Customers == null)
            {
                return NotFound();
            }

            return View(Customers);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customer.Avatar = "/Images/Profile-Avatars/Profile3.jpg";
                    if (id == 0)
                    {
                        _context.Add(customer);

                    }
                    else
                    {
                        _context.Update(customer);
                    }

                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Customer Added successfully." });
                }
                catch (Exception)
                {
                    return Json(new { success = false, message = "An error occurred while saving the customer." });
                }

            }
            else
            {
                return Json(new { success = false, message = "Failed to save Customer." });
            }
   
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Customer = await _context.Customers.FindAsync(id);
            if (Customer != null)
            {
                Customer.Status = "Inactive";
                _context.Update(Customer);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(AllCustomers));
        }
    }
}
