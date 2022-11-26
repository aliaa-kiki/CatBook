using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatBook.Areas.Identity.Data;
using catbook.Models;

namespace CatBook.Controllers
{
    public class traitsController : Controller
    {
        private readonly catBookDbContext _context;

        public traitsController(catBookDbContext context)
        {
            _context = context;
        }

        // GET: traits
        public async Task<IActionResult> Index()
        {
              return View(await _context.traits.ToListAsync());
        }

        // GET: traits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.traits == null)
            {
                return NotFound();
            }

            var trait = await _context.traits
                .FirstOrDefaultAsync(m => m.id == id);
            if (trait == null)
            {
                return NotFound();
            }

            return View(trait);
        }

        // GET: traits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: traits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,type")] trait trait)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trait);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trait);
        }

        // GET: traits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.traits == null)
            {
                return NotFound();
            }

            var trait = await _context.traits.FindAsync(id);
            if (trait == null)
            {
                return NotFound();
            }
            return View(trait);
        }

        // POST: traits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,type")] trait trait)
        {
            if (id != trait.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trait);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!traitExists(trait.id))
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
            return View(trait);
        }

        // GET: traits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.traits == null)
            {
                return NotFound();
            }

            var trait = await _context.traits
                .FirstOrDefaultAsync(m => m.id == id);
            if (trait == null)
            {
                return NotFound();
            }

            return View(trait);
        }

        // POST: traits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.traits == null)
            {
                return Problem("Entity set 'catBookDbContext.traits'  is null.");
            }
            var trait = await _context.traits.FindAsync(id);
            if (trait != null)
            {
                _context.traits.Remove(trait);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool traitExists(int id)
        {
          return _context.traits.Any(e => e.id == id);
        }
    }
}
