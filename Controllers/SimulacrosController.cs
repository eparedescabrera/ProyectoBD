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
    public class SimulacrosController : Controller
    {
        private readonly LiberiaDriveContext _context;

        public SimulacrosController(LiberiaDriveContext context)
        {
            _context = context;
        }

        // GET: Simulacros
        public async Task<IActionResult> Index()
        {
            var liberiaDriveContext = _context.Simulacro.Include(s => s.ID_ClienteNavigation).Include(s => s.ID_InstructorNavigation).Include(s => s.ID_VehiculoNavigation);
            return View(await liberiaDriveContext.ToListAsync());
        }

        // GET: Simulacros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulacro = await _context.Simulacro
                .Include(s => s.ID_ClienteNavigation)
                .Include(s => s.ID_InstructorNavigation)
                .Include(s => s.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(m => m.ID_Simulacro == id);
            if (simulacro == null)
            {
                return NotFound();
            }

            return View(simulacro);
        }

        // GET: Simulacros/Create
        public IActionResult Create()
        {
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente");
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor");
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo");
            return View();
        }

        // POST: Simulacros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Simulacro,ID_Cliente,ID_Instructor,ID_Vehiculo,fecha,tipo,resultado")] Simulacro simulacro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(simulacro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente", simulacro.ID_Cliente);
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", simulacro.ID_Instructor);
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", simulacro.ID_Vehiculo);
            return View(simulacro);
        }

        // GET: Simulacros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulacro = await _context.Simulacro.FindAsync(id);
            if (simulacro == null)
            {
                return NotFound();
            }
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente", simulacro.ID_Cliente);
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", simulacro.ID_Instructor);
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", simulacro.ID_Vehiculo);
            return View(simulacro);
        }

        // POST: Simulacros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Simulacro,ID_Cliente,ID_Instructor,ID_Vehiculo,fecha,tipo,resultado")] Simulacro simulacro)
        {
            if (id != simulacro.ID_Simulacro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(simulacro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SimulacroExists(simulacro.ID_Simulacro))
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
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente", simulacro.ID_Cliente);
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", simulacro.ID_Instructor);
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", simulacro.ID_Vehiculo);
            return View(simulacro);
        }

        // GET: Simulacros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulacro = await _context.Simulacro
                .Include(s => s.ID_ClienteNavigation)
                .Include(s => s.ID_InstructorNavigation)
                .Include(s => s.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(m => m.ID_Simulacro == id);
            if (simulacro == null)
            {
                return NotFound();
            }

            return View(simulacro);
        }

        // POST: Simulacros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var simulacro = await _context.Simulacro.FindAsync(id);
            if (simulacro != null)
            {
                _context.Simulacro.Remove(simulacro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SimulacroExists(int id)
        {
            return _context.Simulacro.Any(e => e.ID_Simulacro == id);
        }
    }
}
