using catbook.Models;
using CatBook.Areas.Identity.Data;
using CatBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace CatBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly catBookDbContext _context;

        public HomeController(catBookDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> explore()
        {
            var model = await _context.cats
                           .Where(predicate: a => a.status == statusStates.available)
                           .ToListAsync();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}