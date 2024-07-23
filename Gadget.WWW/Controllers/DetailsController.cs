using Gadget.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gadget.WWW.Models;
using Gadget.WWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Gadget.Data.Data;
namespace Gadget.WWW.Controllers
{
    public class DetailsController : Controller
    {
        private readonly GadgetIntranetContext _context;

        public DetailsController(GadgetIntranetContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.Products
                .Where(p=>p.Id == id)
                .Include(p=>p.Category)
                .Include(p=>p.Producer)
                .Include(p=>p.ProductSpecification)!
                    .ThenInclude(ps => ps.Specification)
                .FirstAsync();

            return View(item);
        }
    }
}
