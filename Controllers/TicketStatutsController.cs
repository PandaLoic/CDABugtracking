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
    public class TicketStatutsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketStatutsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TicketStatuts
        public async Task<IActionResult> Index()
        {
              return _context.TicketStatut != null ? 
                          View(await _context.TicketStatut.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.TicketStatut'  is null.");
        }

        // GET: TicketStatuts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TicketStatut == null)
            {
                return NotFound();
            }

            var ticketStatut = await _context.TicketStatut
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketStatut == null)
            {
                return NotFound();
            }

            return View(ticketStatut);
        }

        // GET: TicketStatuts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketStatuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TicketStatut ticketStatut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketStatut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketStatut);
        }

        // GET: TicketStatuts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TicketStatut == null)
            {
                return NotFound();
            }

            var ticketStatut = await _context.TicketStatut.FindAsync(id);
            if (ticketStatut == null)
            {
                return NotFound();
            }
            return View(ticketStatut);
        }

        // POST: TicketStatuts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TicketStatut ticketStatut)
        {
            if (id != ticketStatut.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketStatut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketStatutExists(ticketStatut.Id))
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
            return View(ticketStatut);
        }

        // GET: TicketStatuts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TicketStatut == null)
            {
                return NotFound();
            }

            var ticketStatut = await _context.TicketStatut
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketStatut == null)
            {
                return NotFound();
            }

            return View(ticketStatut);
        }

        // POST: TicketStatuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TicketStatut == null)
            {
                return Problem("Entity set 'AppDbContext.TicketStatut'  is null.");
            }
            var ticketStatut = await _context.TicketStatut.FindAsync(id);
            if (ticketStatut != null)
            {
                _context.TicketStatut.Remove(ticketStatut);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketStatutExists(int id)
        {
          return (_context.TicketStatut?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
