using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practica.Config;
using practica.Models;

namespace practica.Controllers
{
    public class RolController : Controller
    {
        private readonly practicadbcontext _context;
        public RolController(practicadbcontext context)
        {
            _context = context;
        }
        // GET: Rol
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New([Bind("Name")] RolModel rol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RolModel rol)
        {
            if (id != rol.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolExists(rol.Id))
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
            return View(rol);
        }

        public bool RolExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var rol = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        }

    }
