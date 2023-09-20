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
    public class ProduitVersionsController : Controller
    {
        private readonly AppDbContext _context;

        public ProduitVersionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProduitVersions
        public async Task<IActionResult> Index()
        {
              return _context.ProduitVersion != null ? 
                          View(await _context.ProduitVersion.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.ProduitVersion'  is null.");
        }

        // GET: ProduitVersions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProduitVersion == null)
            {
                return NotFound();
            }

            var produitVersion = await _context.ProduitVersion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produitVersion == null)
            {
                return NotFound();
            }

            return View(produitVersion);
        }

        // GET: ProduitVersions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProduitVersions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VersionMajeur,VersionMineur,NumeroBuild,DateDebutValidité,DateFinValidit")] ProduitVersion produitVersion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produitVersion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produitVersion);
        }

        // GET: ProduitVersions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProduitVersion == null)
            {
                return NotFound();
            }

            var produitVersion = await _context.ProduitVersion.FindAsync(id);
            if (produitVersion == null)
            {
                return NotFound();
            }
            return View(produitVersion);
        }

        // POST: ProduitVersions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VersionMajeur,VersionMineur,NumeroBuild,DateDebutValidité,DateFinValidit")] ProduitVersion produitVersion)
        {
            if (id != produitVersion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produitVersion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitVersionExists(produitVersion.Id))
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
            return View(produitVersion);
        }

        // GET: ProduitVersions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProduitVersion == null)
            {
                return NotFound();
            }

            var produitVersion = await _context.ProduitVersion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produitVersion == null)
            {
                return NotFound();
            }

            return View(produitVersion);
        }

        // POST: ProduitVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProduitVersion == null)
            {
                return Problem("Entity set 'AppDbContext.ProduitVersion'  is null.");
            }
            var produitVersion = await _context.ProduitVersion.FindAsync(id);
            if (produitVersion != null)
            {
                _context.ProduitVersion.Remove(produitVersion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitVersionExists(int id)
        {
          return (_context.ProduitVersion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
