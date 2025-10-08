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
    public class LeccionesController : Controller
    {
        private readonly LiberiaDriveContext _context;

        public LeccionesController(LiberiaDriveContext context)
        {
            _context = context;
        }

        // GET: Lecciones
        public async Task<IActionResult> Index()
        {
            var liberiaDriveContext = _context.Leccion.Include(l => l.ID_ClienteNavigation).Include(l => l.ID_InstructorNavigation).Include(l => l.ID_VehiculoNavigation);
            return View(await liberiaDriveContext.ToListAsync());
        }

        // GET: Lecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leccion = await _context.Leccion
                .Include(l => l.ID_ClienteNavigation)
                .Include(l => l.ID_InstructorNavigation)
                .Include(l => l.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(m => m.ID_Leccion == id);
            if (leccion == null)
            {
                return NotFound();
            }

            return View(leccion);
        }

        // GET: Lecciones/Create
        public IActionResult Create()
        {
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente");
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor");
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo");
            return View();
        }

        // POST: Lecciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Leccion,ID_Cliente,ID_Instructor,ID_Vehiculo,fecha,hora,tipo,calificacion")] Leccion leccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente", leccion.ID_Cliente);
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", leccion.ID_Instructor);
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", leccion.ID_Vehiculo);
            return View(leccion);
        }

        // GET: Lecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leccion = await _context.Leccion.FindAsync(id);
            if (leccion == null)
            {
                return NotFound();
            }
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente", leccion.ID_Cliente);
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", leccion.ID_Instructor);
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", leccion.ID_Vehiculo);
            return View(leccion);
        }

        // POST: Lecciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Leccion,ID_Cliente,ID_Instructor,ID_Vehiculo,fecha,hora,tipo,calificacion")] Leccion leccion)
        {
            if (id != leccion.ID_Leccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeccionExists(leccion.ID_Leccion))
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
            ViewData["ID_Cliente"] = new SelectList(_context.Cliente, "ID_Cliente", "ID_Cliente", leccion.ID_Cliente);
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", leccion.ID_Instructor);
            ViewData["ID_Vehiculo"] = new SelectList(_context.Vehiculo, "ID_Vehiculo", "ID_Vehiculo", leccion.ID_Vehiculo);
            return View(leccion);
        }

        // GET: Lecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leccion = await _context.Leccion
                .Include(l => l.ID_ClienteNavigation)
                .Include(l => l.ID_InstructorNavigation)
                .Include(l => l.ID_VehiculoNavigation)
                .FirstOrDefaultAsync(m => m.ID_Leccion == id);
            if (leccion == null)
            {
                return NotFound();
            }

            return View(leccion);
        }

        // POST: Lecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leccion = await _context.Leccion.FindAsync(id);
            if (leccion != null)
            {
                _context.Leccion.Remove(leccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeccionExists(int id)
        {
            return _context.Leccion.Any(e => e.ID_Leccion == id);
        }
    }
}
