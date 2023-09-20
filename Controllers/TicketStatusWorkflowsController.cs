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
    public class TicketStatusWorkflowsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketStatusWorkflowsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TicketStatusWorkflows
        public async Task<IActionResult> Index()
        {
              return _context.TicketStatusWorkflow != null ? 
                          View(await _context.TicketStatusWorkflow.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.TicketStatusWorkflow'  is null.");
        }

        // GET: TicketStatusWorkflows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TicketStatusWorkflow == null)
            {
                return NotFound();
            }

            var ticketStatusWorkflow = await _context.TicketStatusWorkflow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketStatusWorkflow == null)
            {
                return NotFound();
            }

            return View(ticketStatusWorkflow);
        }

        // GET: TicketStatusWorkflows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketStatusWorkflows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] TicketStatusWorkflow ticketStatusWorkflow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketStatusWorkflow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketStatusWorkflow);
        }

        // GET: TicketStatusWorkflows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TicketStatusWorkflow == null)
            {
                return NotFound();
            }

            var ticketStatusWorkflow = await _context.TicketStatusWorkflow.FindAsync(id);
            if (ticketStatusWorkflow == null)
            {
                return NotFound();
            }
            return View(ticketStatusWorkflow);
        }

        // POST: TicketStatusWorkflows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] TicketStatusWorkflow ticketStatusWorkflow)
        {
            if (id != ticketStatusWorkflow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketStatusWorkflow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketStatusWorkflowExists(ticketStatusWorkflow.Id))
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
            return View(ticketStatusWorkflow);
        }

        // GET: TicketStatusWorkflows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TicketStatusWorkflow == null)
            {
                return NotFound();
            }

            var ticketStatusWorkflow = await _context.TicketStatusWorkflow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketStatusWorkflow == null)
            {
                return NotFound();
            }

            return View(ticketStatusWorkflow);
        }

        // POST: TicketStatusWorkflows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TicketStatusWorkflow == null)
            {
                return Problem("Entity set 'AppDbContext.TicketStatusWorkflow'  is null.");
            }
            var ticketStatusWorkflow = await _context.TicketStatusWorkflow.FindAsync(id);
            if (ticketStatusWorkflow != null)
            {
                _context.TicketStatusWorkflow.Remove(ticketStatusWorkflow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketStatusWorkflowExists(int id)
        {
          return (_context.TicketStatusWorkflow?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
