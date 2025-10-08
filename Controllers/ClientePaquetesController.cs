using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClientePaquetesController : Controller
    {
        private readonly LiberiaDriveContext _context;

        public ClientePaquetesController(LiberiaDriveContext context)
        {
            _context = context;
        }

        // GET: ClientePaquetes
        public async Task<IActionResult> Index()
        {
            var liberiaDriveContext = _context.Cliente_Paquete.Include(c => c.ID_ClienteNavigation).Include(c => c.ID_PaqueteNavigation);
            return View(await liberiaDriveContext.ToListAsync());
        }

        // GET: ClientePaquetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente_Paquete = await _context.Cliente_Paquete
                .Include(c => c.ID_ClienteNavigation)
                .Include(c => c.ID_PaqueteNavigation)
                .FirstOrDefaultAsync(m => m.ID_ClientePaquete == id);
            if (cliente_Paquete == null)
            {
                return NotFound();
            }

            return View(cliente_Paquete);
        }

        // GET: ClientePaquetes/Create
        public IActionResult Create()
        {
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente");
            ViewData["ID_Paquete"] = new SelectList(_context.Paquete, "ID_Paquete", "ID_Paquete");
            return View();
        }

        // POST: ClientePaquetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_ClientePaquete,ID_Cliente,ID_Paquete,fecha_contratacion")] Cliente_Paquete cliente_Paquete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente_Paquete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente", cliente_Paquete.ID_Cliente);
            ViewData["ID_Paquete"] = new SelectList(_context.Paquete, "ID_Paquete", "ID_Paquete", cliente_Paquete.ID_Paquete);
            return View(cliente_Paquete);
        }

        // GET: ClientePaquetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente_Paquete = await _context.Cliente_Paquete.FindAsync(id);
            if (cliente_Paquete == null)
            {
                return NotFound();
            }
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente", cliente_Paquete.ID_Cliente);
            ViewData["ID_Paquete"] = new SelectList(_context.Paquete, "ID_Paquete", "ID_Paquete", cliente_Paquete.ID_Paquete);
            return View(cliente_Paquete);
        }

        // POST: ClientePaquetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_ClientePaquete,ID_Cliente,ID_Paquete,fecha_contratacion")] Cliente_Paquete cliente_Paquete)
        {
            if (id != cliente_Paquete.ID_ClientePaquete)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente_Paquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cliente_PaqueteExists(cliente_Paquete.ID_ClientePaquete))
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
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente", cliente_Paquete.ID_Cliente);
            ViewData["ID_Paquete"] = new SelectList(_context.Paquete, "ID_Paquete", "ID_Paquete", cliente_Paquete.ID_Paquete);
            return View(cliente_Paquete);
        }

        // GET: ClientePaquetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente_Paquete = await _context.Cliente_Paquete
                .Include(c => c.ID_ClienteNavigation)
                .Include(c => c.ID_PaqueteNavigation)
                .FirstOrDefaultAsync(m => m.ID_ClientePaquete == id);
            if (cliente_Paquete == null)
            {
                return NotFound();
            }

            return View(cliente_Paquete);
        }

        // POST: ClientePaquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente_Paquete = await _context.Cliente_Paquete.FindAsync(id);
            if (cliente_Paquete != null)
            {
                _context.Cliente_Paquete.Remove(cliente_Paquete);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cliente_PaqueteExists(int id)
        {
            return _context.Cliente_Paquete.Any(e => e.ID_ClientePaquete == id);
        }
    }
}
