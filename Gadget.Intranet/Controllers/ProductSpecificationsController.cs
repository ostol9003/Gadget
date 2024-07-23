using Gadget.Data.Data;
using Gadget.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gadget.Intranet.Controllers
{
    public class ProductSpecificationsController : Controller
    {
        private readonly GadgetIntranetContext _context;

        public ProductSpecificationsController(GadgetIntranetContext context)
        {
            _context = context;
        }

        // GET: ProductSpecifications
        public async Task<IActionResult> Index()
        {
            var gadgetIntranetContext = _context.ProductSpecifications.Include(p => p.Product).Include(p => p.Specification);
            return View(await gadgetIntranetContext.ToListAsync());
        }

        // GET: ProductSpecifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSpecification = await _context.ProductSpecifications
                .Include(p => p.Product)
                .Include(p => p.Specification)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productSpecification == null)
            {
                return NotFound();
            }

            return View(productSpecification);
        }

        // GET: ProductSpecifications/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            ViewData["SpecificationId"] = new SelectList(_context.Specifications, "Id", "Name");
            return View();
        }

        // POST: ProductSpecifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,SpecificationId,Value")] ProductSpecification productSpecification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSpecification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", productSpecification.ProductId);
            ViewData["SpecificationId"] = new SelectList(_context.Specifications, "Id", "Name", productSpecification.SpecificationId);
            return View(productSpecification);
        }

        // GET: ProductSpecifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSpecification = await _context.ProductSpecifications.FindAsync(id);
            if (productSpecification == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", productSpecification.ProductId);
            ViewData["SpecificationId"] = new SelectList(_context.Specifications, "Id", "Name", productSpecification.SpecificationId);
            return View(productSpecification);
        }

        // POST: ProductSpecifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,SpecificationId,Value")] ProductSpecification productSpecification)
        {
            if (id != productSpecification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSpecification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSpecificationExists(productSpecification.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description", productSpecification.ProductId);
            ViewData["SpecificationId"] = new SelectList(_context.Specifications, "Id", "Name", productSpecification.SpecificationId);
            return View(productSpecification);
        }

        // GET: ProductSpecifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSpecification = await _context.ProductSpecifications
                .Include(p => p.Product)
                .Include(p => p.Specification)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productSpecification == null)
            {
                return NotFound();
            }

            return View(productSpecification);
        }

        // POST: ProductSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSpecification = await _context.ProductSpecifications.FindAsync(id);
            if (productSpecification != null)
            {
                _context.ProductSpecifications.Remove(productSpecification);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSpecificationExists(int id)
        {
            return _context.ProductSpecifications.Any(e => e.Id == id);
        }
    }
}
