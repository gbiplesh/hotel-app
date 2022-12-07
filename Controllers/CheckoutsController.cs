using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelApp.Data;
using HotelApp.Models;

namespace HotelApp.Controllers
{
    public class CheckoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Checkouts
        public async Task<IActionResult> Index()
        {
              return _context.Checkout != null ? 
                          View(await _context.Checkout.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Checkout'  is null.");
        }

        // GET: Checkouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Checkout == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }

        // GET: Checkouts/Create
        public IActionResult Create(string FullName)
        {
            if(FullName != null)
            {
                var tempFullName = new Checkout()
                {
                    FullName = FullName,
                };

                ViewData["tempFullName"] = tempFullName;
                
                return View();

            }
            return NotFound();
        }

        // POST: Checkouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,PreferredName,Email,Phone,DOB,VerificaitonID")] Checkout checkout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkout);
        }

        // GET: Checkouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Checkout == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkout.FindAsync(id);
            if (checkout == null)
            {
                return NotFound();
            }
            return View(checkout);
        }

        // POST: Checkouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,PreferredName,Email,Phone,DOB,VerificaitonID")] Checkout checkout)
        {
            if (id != checkout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckoutExists(checkout.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(checkout);
        }

        // GET: Checkouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Checkout == null)
            {
                return NotFound();
            }

            var checkout = await _context.Checkout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }

        // POST: Checkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Checkout == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Checkout'  is null.");
            }
            var checkout = await _context.Checkout.FindAsync(id);
            if (checkout != null)
            {
                _context.Checkout.Remove(checkout);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckoutExists(int id)
        {
          return (_context.Checkout?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
