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
    public class RoleAssignationsController : Controller
    {
        private readonly AppDbContext _context;

        public RoleAssignationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RoleAssignations
        public async Task<IActionResult> Index()
        {
              return _context.RoleAssignation != null ? 
                          View(await _context.RoleAssignation.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.RoleAssignation'  is null.");
        }

        // GET: RoleAssignations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoleAssignation == null)
            {
                return NotFound();
            }

            var roleAssignation = await _context.RoleAssignation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleAssignation == null)
            {
                return NotFound();
            }

            return View(roleAssignation);
        }

        // GET: RoleAssignations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoleAssignations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] RoleAssignation roleAssignation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roleAssignation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roleAssignation);
        }

        // GET: RoleAssignations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoleAssignation == null)
            {
                return NotFound();
            }

            var roleAssignation = await _context.RoleAssignation.FindAsync(id);
            if (roleAssignation == null)
            {
                return NotFound();
            }
            return View(roleAssignation);
        }

        // POST: RoleAssignations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] RoleAssignation roleAssignation)
        {
            if (id != roleAssignation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleAssignation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleAssignationExists(roleAssignation.Id))
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
            return View(roleAssignation);
        }

        // GET: RoleAssignations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoleAssignation == null)
            {
                return NotFound();
            }

            var roleAssignation = await _context.RoleAssignation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleAssignation == null)
            {
                return NotFound();
            }

            return View(roleAssignation);
        }

        // POST: RoleAssignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoleAssignation == null)
            {
                return Problem("Entity set 'AppDbContext.RoleAssignation'  is null.");
            }
            var roleAssignation = await _context.RoleAssignation.FindAsync(id);
            if (roleAssignation != null)
            {
                _context.RoleAssignation.Remove(roleAssignation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleAssignationExists(int id)
        {
          return (_context.RoleAssignation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
