using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bugtracking.Data;
using Bugtracking.Models;

namespace Bugtracking.Controllers
{
    public class TicketModificationsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketModificationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TicketModifications
        public async Task<IActionResult> Index()
        {
              return _context.TicketModification != null ? 
                          View(await _context.TicketModification.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.TicketModification'  is null.");
        }

        // GET: TicketModifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TicketModification == null)
            {
                return NotFound();
            }

            var ticketModification = await _context.TicketModification
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketModification == null)
            {
                return NotFound();
            }

            return View(ticketModification);
        }

        // GET: TicketModifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketModifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Commentaire,Date")] TicketModification ticketModification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketModification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketModification);
        }

        // GET: TicketModifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TicketModification == null)
            {
                return NotFound();
            }

            var ticketModification = await _context.TicketModification.FindAsync(id);
            if (ticketModification == null)
            {
                return NotFound();
            }
            return View(ticketModification);
        }

        // POST: TicketModifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Commentaire,Date")] TicketModification ticketModification)
        {
            if (id != ticketModification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketModification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketModificationExists(ticketModification.Id))
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
            return View(ticketModification);
        }

        // GET: TicketModifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TicketModification == null)
            {
                return NotFound();
            }

            var ticketModification = await _context.TicketModification
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketModification == null)
            {
                return NotFound();
            }

            return View(ticketModification);
        }

        // POST: TicketModifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TicketModification == null)
            {
                return Problem("Entity set 'AppDbContext.TicketModification'  is null.");
            }
            var ticketModification = await _context.TicketModification.FindAsync(id);
            if (ticketModification != null)
            {
                _context.TicketModification.Remove(ticketModification);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketModificationExists(int id)
        {
          return (_context.TicketModification?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
