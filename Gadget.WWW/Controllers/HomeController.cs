using Gadget.WWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Gadget.Data.Data;

namespace Gadget.WWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GadgetIntranetContext _context;

        public HomeController(ILogger<HomeController> logger, GadgetIntranetContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {

          
            //viewBag bedzie w gornej czesci layoutu wyswietlic wszystkie rodzaje towarow
            //ViewBag.Rodzaje = await _context.Rodzaj.ToListAsync();
            if (id == null)
            {
                id = 1; // to beda domyslnie towary promowane
            }
            //do items ladujemy wszystkie towary o danym rodzaju
            var items = await _context.Products
                .Include(p=> p.Producer)
                .Include(p => p.ProductSpecification)!
                .ThenInclude(ps => ps.Specification)
                .ToListAsync();


            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
