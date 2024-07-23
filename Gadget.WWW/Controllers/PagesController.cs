using Gadget.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gadget.WWW.Controllers
{
    public class PagesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GadgetIntranetContext _context;

        public PagesController(ILogger<HomeController> logger, GadgetIntranetContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ModelStrony = await _context.Page.OrderBy(s => s.Position).ToListAsync();

            if (id == null)
                id = 2; //koniecznie powinna byc srona o id = 1
            // w bazie danych szukam strony o danym id
            var item = await _context.Page.FindAsync(id);
            // i te strone przekazuje do widoku
            return View(item);
        }
    }
}
