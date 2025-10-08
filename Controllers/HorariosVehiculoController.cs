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
    public class HorariosVehiculoController : Controller
    {
        private readonly LiberiaDriveContext _context;

        public HorariosVehiculoController(LiberiaDriveContext context)
        {
            _context = context;
        }

        // GET: HorariosVehiculo
        public async Task<IActionResult> Index()
        {
            var liberiaDriveContext = _context.Horario_Vehiculo.Include(h => h.ID_VehiculoNavigation);
            return View(await liberiaDriveContext.ToListAsync());
        }

        // GET: HorariosVehiculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario_Vehiculo = await _context.Horario_Vehiculo
                .Include(h => h.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(m => m.ID_HorarioVehiculo == id);
            if (horario_Vehiculo == null)
            {
                return NotFound();
            }

            return View(horario_Vehiculo);
        }

        // GET: HorariosVehiculo/Create
        public IActionResult Create()
        {
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo");
            return View();
        }

        // POST: HorariosVehiculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_HorarioVehiculo,ID_Vehiculo,dia_semana,hora_inicio,hora_fin")] Horario_Vehiculo horario_Vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario_Vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", horario_Vehiculo.ID_Vehiculo);
            return View(horario_Vehiculo);
        }

        // GET: HorariosVehiculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario_Vehiculo = await _context.Horario_Vehiculo.FindAsync(id);
            if (horario_Vehiculo == null)
            {
                return NotFound();
            }
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", horario_Vehiculo.ID_Vehiculo);
            return View(horario_Vehiculo);
        }

        // POST: HorariosVehiculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_HorarioVehiculo,ID_Vehiculo,dia_semana,hora_inicio,hora_fin")] Horario_Vehiculo horario_Vehiculo)
        {
            if (id != horario_Vehiculo.ID_HorarioVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario_Vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Horario_VehiculoExists(horario_Vehiculo.ID_HorarioVehiculo))
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
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", horario_Vehiculo.ID_Vehiculo);
            return View(horario_Vehiculo);
        }

        // GET: HorariosVehiculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario_Vehiculo = await _context.Horario_Vehiculo
                .Include(h => h.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(m => m.ID_HorarioVehiculo == id);
            if (horario_Vehiculo == null)
            {
                return NotFound();
            }

            return View(horario_Vehiculo);
        }

        // POST: HorariosVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario_Vehiculo = await _context.Horario_Vehiculo.FindAsync(id);
            if (horario_Vehiculo != null)
            {
                _context.Horario_Vehiculo.Remove(horario_Vehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Horario_VehiculoExists(int id)
        {
            return _context.Horario_Vehiculo.Any(e => e.ID_HorarioVehiculo == id);
        }
    }
}
