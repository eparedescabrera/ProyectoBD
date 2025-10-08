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
    public class DisponibilidadesVehiculoController : Controller
    {
        private readonly LiberiaDriveContext _context;

        public DisponibilidadesVehiculoController(LiberiaDriveContext context)
        {
            _context = context;
        }

        // GET: DisponibilidadesVehiculo
        public async Task<IActionResult> Index()
        {
            var liberiaDriveContext = _context.Disponibilidad_Vehiculo.Include(d => d.ID_VehiculoNavigation);
            return View(await liberiaDriveContext.ToListAsync());
        }

        // GET: DisponibilidadesVehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad_Vehiculo = await _context.Disponibilidad_Vehiculo
                .Include(d => d.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(m => m.ID_DisponibilidadVehiculo == id);
            if (disponibilidad_Vehiculo == null)
            {
                return NotFound();
            }

            return View(disponibilidad_Vehiculo);
        }

        // GET: DisponibilidadesVehiculo/Create
        public IActionResult Create()
        {
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo");
            return View();
        }

        // POST: DisponibilidadesVehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_DisponibilidadVehiculo,ID_Vehiculo,fecha,hora_inicio,hora_fin,estado")] Disponibilidad_Vehiculo disponibilidad_Vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disponibilidad_Vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", disponibilidad_Vehiculo.ID_Vehiculo);
            return View(disponibilidad_Vehiculo);
        }

        // GET: DisponibilidadesVehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad_Vehiculo = await _context.Disponibilidad_Vehiculo.FindAsync(id);
            if (disponibilidad_Vehiculo == null)
            {
                return NotFound();
            }
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", disponibilidad_Vehiculo.ID_Vehiculo);
            return View(disponibilidad_Vehiculo);
        }

        // POST: DisponibilidadesVehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_DisponibilidadVehiculo,ID_Vehiculo,fecha,hora_inicio,hora_fin,estado")] Disponibilidad_Vehiculo disponibilidad_Vehiculo)
        {
            if (id != disponibilidad_Vehiculo.ID_DisponibilidadVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disponibilidad_Vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Disponibilidad_VehiculoExists(disponibilidad_Vehiculo.ID_DisponibilidadVehiculo))
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
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", disponibilidad_Vehiculo.ID_Vehiculo);
            return View(disponibilidad_Vehiculo);
        }

        // GET: DisponibilidadesVehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad_Vehiculo = await _context.Disponibilidad_Vehiculo
                .Include(d => d.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(m => m.ID_DisponibilidadVehiculo == id);
            if (disponibilidad_Vehiculo == null)
            {
                return NotFound();
            }

            return View(disponibilidad_Vehiculo);
        }

        // POST: DisponibilidadesVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disponibilidad_Vehiculo = await _context.Disponibilidad_Vehiculo.FindAsync(id);
            if (disponibilidad_Vehiculo != null)
            {
                _context.Disponibilidad_Vehiculo.Remove(disponibilidad_Vehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Disponibilidad_VehiculoExists(int id)
        {
            return _context.Disponibilidad_Vehiculo.Any(e => e.ID_DisponibilidadVehiculo == id);
        }
    }
}
