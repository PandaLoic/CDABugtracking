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
    public class TicketAssignationsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketAssignationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TicketAssignations
        public async Task<IActionResult> Index()
        {
              return _context.TicketAssignation != null ? 
                          View(await _context.TicketAssignation.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.TicketAssignation'  is null.");
        }

        // GET: TicketAssignations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TicketAssignation == null)
            {
                return NotFound();
            }

            var ticketAssignation = await _context.TicketAssignation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketAssignation == null)
            {
                return NotFound();
            }

            return View(ticketAssignation);
        }

        // GET: TicketAssignations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketAssignations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] TicketAssignation ticketAssignation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketAssignation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketAssignation);
        }

        // GET: TicketAssignations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TicketAssignation == null)
            {
                return NotFound();
            }

            var ticketAssignation = await _context.TicketAssignation.FindAsync(id);
            if (ticketAssignation == null)
            {
                return NotFound();
            }
            return View(ticketAssignation);
        }

        // POST: TicketAssignations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] TicketAssignation ticketAssignation)
        {
            if (id != ticketAssignation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketAssignation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketAssignationExists(ticketAssignation.Id))
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
            return View(ticketAssignation);
        }

        // GET: TicketAssignations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TicketAssignation == null)
            {
                return NotFound();
            }

            var ticketAssignation = await _context.TicketAssignation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketAssignation == null)
            {
                return NotFound();
            }

            return View(ticketAssignation);
        }

        // POST: TicketAssignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TicketAssignation == null)
            {
                return Problem("Entity set 'AppDbContext.TicketAssignation'  is null.");
            }
            var ticketAssignation = await _context.TicketAssignation.FindAsync(id);
            if (ticketAssignation != null)
            {
                _context.TicketAssignation.Remove(ticketAssignation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketAssignationExists(int id)
        {
          return (_context.TicketAssignation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
