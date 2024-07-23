using Gadget.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gadget.WWW.Controllers
{
    public class PagesComponent : ViewComponent
    {
        private readonly GadgetIntranetContext _context;

        public PagesComponent(GadgetIntranetContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("PagesComponent", await _context.Page.OrderBy(p=>p.Position).ToListAsync());
        }
    }
}
