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
    public class requestsController : Controller
    {
        private readonly catBookDbContext _context;

        public requestsController(catBookDbContext context)
        {
            _context = context;
        }

        // GET: requests
        public async Task<IActionResult> Index()
        {
            var catBookDbContext = _context.requests.Include(r => r.requestedCat).Include(r => r.senderUser);
            return View(await catBookDbContext.ToListAsync());
        }

        // GET: requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.requests == null)
            {
                return NotFound();
            }

            var request = await _context.requests
                .Include(r => r.requestedCat)
                .Include(r => r.senderUser)
                .FirstOrDefaultAsync(m => m.id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: requests/Create
        public IActionResult Create(string _requestedCat)
        {
            ViewData["catId"] = new SelectList(_requestedCat);
            ViewData["senderUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,senderUserId,catId,message,contact")] request request)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Model state state is valid");
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            System.Diagnostics.Debug.WriteLine("Model state state is NOT valid");
            ViewData["catId"] = new SelectList(_context.cats, "id", "id", request.catId);
            ViewData["senderUserId"] = new SelectList(_context.Users, "Id", "Id", request.senderUserId);
            return View(request);
        }

        // GET: requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.requests == null)
            {
                return NotFound();
            }

            var request = await _context.requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["catId"] = new SelectList(_context.cats, "id", "id", request.catId);
            ViewData["senderUserId"] = new SelectList(_context.Users, "Id", "Id", request.senderUserId);
            return View(request);
        }

        // POST: requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,senderUserId,catId,message,contact")] request request)
        {
            if (id != request.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!requestExists(request.id))
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
            ViewData["catId"] = new SelectList(_context.cats, "id", "id", request.catId);
            ViewData["senderUserId"] = new SelectList(_context.Users, "Id", "Id", request.senderUserId);
            return View(request);
        }

        // GET: requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.requests == null)
            {
                return NotFound();
            }

            var request = await _context.requests
                .Include(r => r.requestedCat)
                .Include(r => r.senderUser)
                .FirstOrDefaultAsync(m => m.id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.requests == null)
            {
                return Problem("Entity set 'catBookDbContext.requests'  is null.");
            }
            var request = await _context.requests.FindAsync(id);
            if (request != null)
            {
                _context.requests.Remove(request);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool requestExists(int id)
        {
          return _context.requests.Any(e => e.id == id);
        }
    }
}
