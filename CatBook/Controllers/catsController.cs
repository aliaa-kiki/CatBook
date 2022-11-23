using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatBook.Data;
using catbook.Models;

namespace CatBook.Controllers
{
    public class catsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public catsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: cats
        public async Task<IActionResult> Index()
        {
              return View(await _context.cat.ToListAsync());
        }

        // GET: cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cat == null)
            {
                return NotFound();
            }

            var cat = await _context.cat
                .FirstOrDefaultAsync(m => m.id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // GET: cats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,photo,about,status,vaccinated,neutered,vaccinationbook")] cat cat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cat);
        }

        // GET: cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cat == null)
            {
                return NotFound();
            }

            var cat = await _context.cat.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: cats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,photo,about,status,vaccinated,neutered,vaccinationbook")] cat cat)
        {
            if (id != cat.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!catExists(cat.id))
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
            return View(cat);
        }

        // GET: cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cat == null)
            {
                return NotFound();
            }

            var cat = await _context.cat
                .FirstOrDefaultAsync(m => m.id == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cat == null)
            {
                return Problem("Entity set 'ApplicationDbContext.cat'  is null.");
            }
            var cat = await _context.cat.FindAsync(id);
            if (cat != null)
            {
                _context.cat.Remove(cat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool catExists(int id)
        {
          return _context.cat.Any(e => e.id == id);
        }
    }
}
