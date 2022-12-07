using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelApp.Data;
using HotelApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace HotelApp.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
              return _context.Rooms != null ? 
                          View(await _context.Rooms.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Rooms'  is null.");
        }

        // GET: Rooms/ShowSearchForm
        public ViewResult ShowSearchForm()
        {
            return View();
        }

        // POST: Rooms/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return _context.Rooms != null ? View("Index", await _context.Rooms
                .Where(r => r.RoomType.Contains(SearchPhrase)).ToListAsync()) :
                Problem("Rooms data is null.");
        }


        // GET: Rooms/RoomsSelected
        
        public ActionResult RoomsSelected(int id, int RoomQuantity, string FullName, string CheckIn, string CheckOut)
        {
            if (_context.Rooms != null)
            {
                var rooms =  _context.Rooms
                .Single(m => m.Id == id);

                var tempRoom = new Rooms()
                {
                    Id = id,
                    RoomType = rooms.RoomType,
                    Price = rooms.Price,
                };

                
                return RedirectToAction("BookingOptions", "Bookings",
                    new
                    {
                        amount = RoomQuantity,
                        id = tempRoom.Id,
                        roomType = tempRoom.RoomType,
                        price = tempRoom.Price,
                        fullName = FullName,
                        CheckIn = CheckIn,
                        CheckOut = CheckOut
                    });
            }
            return NotFound();
        }


        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var rooms = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rooms == null)
            {
                return NotFound();
            }

            return View(rooms);
        }

        // GET: Rooms/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomType,Price,Available")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rooms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rooms);
        }

        // GET: Rooms/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var rooms = await _context.Rooms.FindAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }
            return View(rooms);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomType,Price,Available")] Rooms rooms)
        {
            if (id != rooms.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rooms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomsExists(rooms.Id))
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
            return View(rooms);
        }

        // GET: Rooms/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var rooms = await _context.Rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rooms == null)
            {
                return NotFound();
            }

            return View(rooms);
        }

        // POST: Rooms/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rooms'  is null.");
            }
            var rooms = await _context.Rooms.FindAsync(id);
            if (rooms != null)
            {
                _context.Rooms.Remove(rooms);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomsExists(int id)
        {
          return (_context.Rooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
