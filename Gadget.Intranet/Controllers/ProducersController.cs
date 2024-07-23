using Gadget.Data.Data;
using Gadget.Data.Data.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gadget.Intranet.Controllers
{
    public class ProducersController : Controller
    {
        private readonly GadgetIntranetContext _context;

        public ProducersController(GadgetIntranetContext context)
        {
            _context = context;
        }

        // GET: Producers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producerss.ToListAsync());
        }

        // GET: Producerss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Producers = await _context.Producerss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Producers == null)
            {
                return NotFound();
            }

            return View(Producers);
        }

        // GET: Producerss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producerss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Producers Producers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Producers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Producers);
        }

        // GET: Producerss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Producers = await _context.Producerss.FindAsync(id);
            if (Producers == null)
            {
                return NotFound();
            }
            return View(Producers);
        }

        // POST: Producerss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Producers Producerss)
        {
            if (id != Producerss.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Producerss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducersExists(Producerss.Id))
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
            return View(Producerss);
        }

        // GET: Producerss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Producers = await _context.Producerss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Producers == null)
            {
                return NotFound();
            }

            return View(Producers);
        }

        // POST: Producerss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Producers = await _context.Producerss.FindAsync(id);
            if (Producers != null)
            {
                _context.Producerss.Remove(Producers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducersExists(int id)
        {
            return _context.Producerss.Any(e => e.Id == id);
        }
    }
}
