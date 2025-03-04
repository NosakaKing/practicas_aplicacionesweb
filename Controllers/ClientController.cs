using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using practica.Config;
using practica.Models;

namespace practica.Controllers
{
    public class ClientController : Controller
    {
        private readonly practicadbcontext _context;
        private readonly ILogger<ClientController> _logger;

        public ClientController(practicadbcontext context, ILogger<ClientController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var practicadbcontext = _context.Clients.Include(c => c.Rol);
            return View(await practicadbcontext.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.Clients
                .Include(c => c.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientModel == null)
            {
                return NotFound();
            }

            return View(clientModel);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cedula_RUC,Name,LastName,Email,Phone,Address,RolId,Age,Gender,DateOfBirth")] ClientModel clientModel)
        {
            _logger.LogInformation("Entering Create POST method");

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model state is valid");
                _context.Add(clientModel);
                await _context.SaveChangesAsync();
                _logger.LogInformation("ClientModel saved successfully");
                return RedirectToAction(nameof(Index));
            }

            _logger.LogWarning("Model state is invalid");
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    _logger.LogError(error.ErrorMessage);
                }
            }

            ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Name", clientModel.RolId);
            return View(clientModel);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.Clients.FindAsync(id);
            if (clientModel == null)
            {
                return NotFound();
            }
            ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Name", clientModel.RolId);
            return View(clientModel);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cedula_RUC,Name,LastName,Email,Phone,Address,RolId,Age,Gender,DateOfBirth")] ClientModel clientModel)
        {
            if (id != clientModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientModelExists(clientModel.Id))
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
            ViewData["RolId"] = new SelectList(_context.Roles, "Id", "Name", clientModel.RolId);
            return View(clientModel);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModel = await _context.Clients
                .Include(c => c.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientModel == null)
            {
                return NotFound();
            }

            return View(clientModel);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientModel = await _context.Clients.FindAsync(id);
            if (clientModel != null)
            {
                _context.Clients.Remove(clientModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientModelExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}

