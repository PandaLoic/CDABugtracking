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
    public class produitsController : Controller
    {
        private readonly AppDbContext _context;

        public produitsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: produits
        public async Task<IActionResult> Index()
        {
              return _context.produit != null ? 
                          View(await _context.produit.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.produit'  is null.");
        }

        // GET: produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.produit == null)
            {
                return NotFound();
            }

            var produit = await _context.produit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // GET: produits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
        }

        // GET: produits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.produit == null)
            {
                return NotFound();
            }

            var produit = await _context.produit.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return View(produit);
        }

        // POST: produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] produit produit)
        {
            if (id != produit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!produitExists(produit.Id))
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
            return View(produit);
        }

        // GET: produits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.produit == null)
            {
                return NotFound();
            }

            var produit = await _context.produit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // POST: produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.produit == null)
            {
                return Problem("Entity set 'AppDbContext.produit'  is null.");
            }
            var produit = await _context.produit.FindAsync(id);
            if (produit != null)
            {
                _context.produit.Remove(produit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool produitExists(int id)
        {
          return (_context.produit?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
