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
    public class MantenimientosVehiculoController : Controller
    {
        private readonly LiberiaDriveContext _context;

        public MantenimientosVehiculoController(LiberiaDriveContext context)
        {
            _context = context;
        }

        // GET: MantenimientosVehiculo
        public async Task<IActionResult> Index()
        {
            var liberiaDriveContext = _context.Mantenimiento_Vehiculo.Include(m => m.ID_VehiculoNavigation);
            return View(await liberiaDriveContext.ToListAsync());
        }

        // GET: MantenimientosVehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimiento_Vehiculo = await _context.Mantenimiento_Vehiculo
                .Include(m => m.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(m => m.ID_Mantenimiento == id);
            if (mantenimiento_Vehiculo == null)
            {
                return NotFound();
            }

            return View(mantenimiento_Vehiculo);
        }

        // GET: MantenimientosVehiculo/Create
        public IActionResult Create()
        {
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo");
            return View();
        }

        // POST: MantenimientosVehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Mantenimiento,ID_Vehiculo,fecha,tipo,costo,estado,kilometraje")] Mantenimiento_Vehiculo mantenimiento_Vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mantenimiento_Vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", mantenimiento_Vehiculo.ID_Vehiculo);
            return View(mantenimiento_Vehiculo);
        }

        // GET: MantenimientosVehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimiento_Vehiculo = await _context.Mantenimiento_Vehiculo.FindAsync(id);
            if (mantenimiento_Vehiculo == null)
            {
                return NotFound();
            }
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", mantenimiento_Vehiculo.ID_Vehiculo);
            return View(mantenimiento_Vehiculo);
        }

        // POST: MantenimientosVehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Mantenimiento,ID_Vehiculo,fecha,tipo,costo,estado,kilometraje")] Mantenimiento_Vehiculo mantenimiento_Vehiculo)
        {
            if (id != mantenimiento_Vehiculo.ID_Mantenimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mantenimiento_Vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mantenimiento_VehiculoExists(mantenimiento_Vehiculo.ID_Mantenimiento))
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
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", mantenimiento_Vehiculo.ID_Vehiculo);
            return View(mantenimiento_Vehiculo);
        }

        // GET: MantenimientosVehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mantenimiento_Vehiculo = await _context.Mantenimiento_Vehiculo
                .Include(m => m.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(m => m.ID_Mantenimiento == id);
            if (mantenimiento_Vehiculo == null)
            {
                return NotFound();
            }

            return View(mantenimiento_Vehiculo);
        }

        // POST: MantenimientosVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mantenimiento_Vehiculo = await _context.Mantenimiento_Vehiculo.FindAsync(id);
            if (mantenimiento_Vehiculo != null)
            {
                _context.Mantenimiento_Vehiculo.Remove(mantenimiento_Vehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mantenimiento_VehiculoExists(int id)
        {
            return _context.Mantenimiento_Vehiculo.Any(e => e.ID_Mantenimiento == id);
        }
    }
}
