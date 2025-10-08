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
    public class DisponibilidadesInstructorController : Controller
    {
        private readonly LiberiaDriveContext _context;

        public DisponibilidadesInstructorController(LiberiaDriveContext context)
        {
            _context = context;
        }

        // GET: DisponibilidadesInstructor
        public async Task<IActionResult> Index()
        {
            var liberiaDriveContext = _context.Disponibilidad_Instructor.Include(d => d.ID_InstructorNavigation);
            return View(await liberiaDriveContext.ToListAsync());
        }

        // GET: DisponibilidadesInstructor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad_Instructor = await _context.Disponibilidad_Instructor
                .Include(d => d.ID_InstructorNavigation)
                .FirstOrDefaultAsync(m => m.ID_DisponibilidadInstructor == id);
            if (disponibilidad_Instructor == null)
            {
                return NotFound();
            }

            return View(disponibilidad_Instructor);
        }

        // GET: DisponibilidadesInstructor/Create
        public IActionResult Create()
        {
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor");
            return View();
        }

        // POST: DisponibilidadesInstructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_DisponibilidadInstructor,ID_Instructor,fecha,hora_inicio,hora_fin,estado")] Disponibilidad_Instructor disponibilidad_Instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disponibilidad_Instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", disponibilidad_Instructor.ID_Instructor);
            return View(disponibilidad_Instructor);
        }

        // GET: DisponibilidadesInstructor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad_Instructor = await _context.Disponibilidad_Instructor.FindAsync(id);
            if (disponibilidad_Instructor == null)
            {
                return NotFound();
            }
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", disponibilidad_Instructor.ID_Instructor);
            return View(disponibilidad_Instructor);
        }

        // POST: DisponibilidadesInstructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_DisponibilidadInstructor,ID_Instructor,fecha,hora_inicio,hora_fin,estado")] Disponibilidad_Instructor disponibilidad_Instructor)
        {
            if (id != disponibilidad_Instructor.ID_DisponibilidadInstructor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disponibilidad_Instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Disponibilidad_InstructorExists(disponibilidad_Instructor.ID_DisponibilidadInstructor))
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
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", disponibilidad_Instructor.ID_Instructor);
            return View(disponibilidad_Instructor);
        }

        // GET: DisponibilidadesInstructor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad_Instructor = await _context.Disponibilidad_Instructor
                .Include(d => d.ID_InstructorNavigation)
                .FirstOrDefaultAsync(m => m.ID_DisponibilidadInstructor == id);
            if (disponibilidad_Instructor == null)
            {
                return NotFound();
            }

            return View(disponibilidad_Instructor);
        }

        // POST: DisponibilidadesInstructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disponibilidad_Instructor = await _context.Disponibilidad_Instructor.FindAsync(id);
            if (disponibilidad_Instructor != null)
            {
                _context.Disponibilidad_Instructor.Remove(disponibilidad_Instructor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Disponibilidad_InstructorExists(int id)
        {
            return _context.Disponibilidad_Instructor.Any(e => e.ID_DisponibilidadInstructor == id);
        }
    }
}
