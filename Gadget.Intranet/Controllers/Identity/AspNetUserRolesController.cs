using Gadget.Data.Data;
using Gadget.Data.Data.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gadget.Intranet.Controllers.Identity
{
    public class AspNetUserRolesController : Controller
    {
        private readonly GadgetIntranetContext _context;

        public AspNetUserRolesController(GadgetIntranetContext context)
        {
            _context = context;
        }
        // GET: AspNetUserRoles
        public async Task<IActionResult> Index()
        {
                var userRolesWithUserInfo = await _context.UserRoles
                    .Join(
                        _context.Users,
                        ur => ur.UserId,
                        u => u.Id,
                        (ur, u) => new { ur, u }
                    )
                    .Join(
                        _context.Roles,
                        combined => combined.ur.RoleId,
                        r => r.Id,
                        (combined, r) => new UsersRolesNames()
                        {
                            UserId = combined.ur.UserId,
                            UserName = combined.u.UserName,
                            RoleId = combined.ur.RoleId,
                            RoleName = r.Name
                        }
                    )
                    .ToListAsync();

                return View(userRolesWithUserInfo);
       
        }
       
        // GET: AspNetUserRoles/Create
        public ActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["RolesId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: AspNetUserRoles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId, UserId")] IdentityUserRole<string> aspNetUserRole)
        {
            if (ModelState.IsValid)
            {
                //var query = $"INSERT INTO UserRoles (RoleId, UserId) VALUES ('{aspNetUserRole.RoleId}', '{aspNetUserRole.UserId}')";
                _context.Add(aspNetUserRole);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(aspNetUserRole);
        }



        // GET: AspNetUserRoles/Edit/5
        public async Task<IActionResult> Edit(string roleId, string userId)
        {
            if (roleId == null || userId == null)
            {
                return NotFound();
            }

            var aspNetURole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.RoleId == roleId && ur.UserId == userId);
            if (aspNetURole == null)
            {
                return NotFound();
            }
            return View(aspNetURole);
        }
        // POST: AspNetUserRoles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string roleId,string userId, [Bind("UserId,RoleId")] IdentityUserRole<string> aspNetUserRole)
        {
            if (roleId != aspNetUserRole.RoleId || userId != aspNetUserRole.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetUserRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUserRoleExists(aspNetUserRole.RoleId,aspNetUserRole.UserId))
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
            return View(aspNetUserRole);
        }


        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string roleId, string userId)
        {
            var aspNetUserRole = await _context.UserRoles.FirstOrDefaultAsync(ur=> ur.RoleId == roleId && ur.UserId == userId);
            if (aspNetUserRole != null)
            {
                _context.UserRoles.Remove(aspNetUserRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
        private bool AspNetUserRoleExists(string roleId,string userId)
        {
            return _context.UserRoles.Any(e => e.RoleId == roleId && e.UserId == userId);
        }
    }
}
