using Gadget.Data.Data;
using Gadget.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gadget.WWW.Controllers
{
    public class PhoneController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GadgetIntranetContext _context;

        public PhoneController(ILogger<HomeController> logger, GadgetIntranetContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var items =  _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Name == "Phone")
                .Include(p => p.Producer)
                .Include(p => p.ProductSpecification)!
                .ThenInclude(ps => ps.Specification);

            if (!string.IsNullOrEmpty(searchString))
            {
                var item = await items.Where(p => p.Name.Contains(searchString)).ToListAsync();
                return View(item);
            }
            else
            {
                var products = await items.ToListAsync();

                return View(products);
            }
            
        }
        public async Task<IActionResult> Tablet(string searchString)
        {
            var items = _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Name == "Tablet")
                .Include(p => p.Producer)
                .Include(p => p.ProductSpecification)!
                .ThenInclude(ps => ps.Specification);

            if (!string.IsNullOrEmpty(searchString))
            {
                var item = await items.Where(p => p.Name.Contains(searchString)).ToListAsync();
                return View(item);
            }
            else
            {
                var products = await items.ToListAsync();

                return View(products);
            }

        }
        public async Task<IActionResult> Deal(string searchString)
        {
            var items = _context.Products
                .Include(p => p.Category)
                .Where(p=> p.IsPromoted == true)
                .Include(p => p.Producer)
                .Include(p => p.ProductSpecification)!
                .ThenInclude(ps => ps.Specification);


            if (!string.IsNullOrEmpty(searchString))
            {
                var item = await items.Where(p => p.Category.Name.Contains(searchString)).ToListAsync();
                return View(item);
            }
            else
            {
                var products = await items.ToListAsync();

                return View(products);
            }


        }

    }
}
