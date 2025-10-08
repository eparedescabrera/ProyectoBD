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
    public class HorariosInstructorController : Controller
    {
        private readonly LiberiaDriveContext _context;

        public HorariosInstructorController(LiberiaDriveContext context)
        {
            _context = context;
        }

        // GET: HorariosInstructor
        public async Task<IActionResult> Index()
        {
            var liberiaDriveContext = _context.Horario_Instructor.Include(h => h.ID_InstructorNavigation);
            return View(await liberiaDriveContext.ToListAsync());
        }

        // GET: HorariosInstructor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario_Instructor = await _context.Horario_Instructor
                .Include(h => h.ID_InstructorNavigation)
                .FirstOrDefaultAsync(m => m.ID_HorarioInstructor == id);
            if (horario_Instructor == null)
            {
                return NotFound();
            }

            return View(horario_Instructor);
        }

        // GET: HorariosInstructor/Create
        public IActionResult Create()
        {
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor");
            return View();
        }

        // POST: HorariosInstructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_HorarioInstructor,ID_Instructor,dia_semana,hora_inicio,hora_fin")] Horario_Instructor horario_Instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario_Instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", horario_Instructor.ID_Instructor);
            return View(horario_Instructor);
        }

        // GET: HorariosInstructor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario_Instructor = await _context.Horario_Instructor.FindAsync(id);
            if (horario_Instructor == null)
            {
                return NotFound();
            }
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", horario_Instructor.ID_Instructor);
            return View(horario_Instructor);
        }

        // POST: HorariosInstructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_HorarioInstructor,ID_Instructor,dia_semana,hora_inicio,hora_fin")] Horario_Instructor horario_Instructor)
        {
            if (id != horario_Instructor.ID_HorarioInstructor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario_Instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Horario_InstructorExists(horario_Instructor.ID_HorarioInstructor))
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
            ViewData["ID_Instructor"] = new SelectList(_context.Instructor, "ID_Instructor", "ID_Instructor", horario_Instructor.ID_Instructor);
            return View(horario_Instructor);
        }

        // GET: HorariosInstructor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horario_Instructor = await _context.Horario_Instructor
                .Include(h => h.ID_InstructorNavigation)
                .FirstOrDefaultAsync(m => m.ID_HorarioInstructor == id);
            if (horario_Instructor == null)
            {
                return NotFound();
            }

            return View(horario_Instructor);
        }

        // POST: HorariosInstructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario_Instructor = await _context.Horario_Instructor.FindAsync(id);
            if (horario_Instructor != null)
            {
                _context.Horario_Instructor.Remove(horario_Instructor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Horario_InstructorExists(int id)
        {
            return _context.Horario_Instructor.Any(e => e.ID_HorarioInstructor == id);
        }
    }
}
