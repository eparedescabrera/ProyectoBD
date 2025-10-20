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
    public class CitasController : Controller
    {
        private readonly LiberiaDriveContext _context;

        public CitasController(LiberiaDriveContext context)
        {
            _context = context;
        }

        // GET: Citas
        public async Task<IActionResult> Index()
        {
            return View(await GetCitasWithCliente().ToListAsync());
        }

        // GET: Citas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await GetCitasWithCliente()
                .FirstOrDefaultAsync(m => m.ID_Cita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Citas/Create
        public IActionResult Create()
        {
            PopulateClientesDropDownList();
            return View();
        }

        // POST: Citas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Cita,ID_Cliente,fecha,tipo,estado,observaciones")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                SetSweetAlert("Cita creada", "La cita se registró correctamente.");
                return RedirectToAction(nameof(Index));
            }
            PopulateClientesDropDownList(cita.ID_Cliente);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            PopulateClientesDropDownList(cita.ID_Cliente);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Cita,ID_Cliente,fecha,tipo,estado,observaciones")] Cita cita)
        {
            if (id != cita.ID_Cita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                    SetSweetAlert("Cita actualizada", "Los cambios se guardaron correctamente.");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.ID_Cita))
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
            PopulateClientesDropDownList(cita.ID_Cliente);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await GetCitasWithCliente()
                .FirstOrDefaultAsync(m => m.ID_Cita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            if (cita != null)
            {
                _context.Cita.Remove(cita);
            }

            await _context.SaveChangesAsync();
            SetSweetAlert("Cita eliminada", "La cita se eliminó correctamente.");
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.AsNoTracking().Any(e => e.ID_Cita == id);
        }

        private IQueryable<Cita> GetCitasWithCliente()
        {
            return _context.Cita
                .AsNoTracking()
                .Include(c => c.ID_ClienteNavigation);
        }

        private void PopulateClientesDropDownList(int? selectedCliente = null)
        {
            var clientes = _context.Cliente
                .AsNoTracking()
                .OrderBy(c => c.ID_Cliente);

            ViewData["ID_Cliente"] = new SelectList(clientes, "ID_Cliente", "ID_Cliente", selectedCliente);
        }

        private const string SweetAlertTitleKey = "SweetAlert.Title";
        private const string SweetAlertMessageKey = "SweetAlert.Message";
        private const string SweetAlertIconKey = "SweetAlert.Icon";

        private void SetSweetAlert(string title, string message, string icon = "success")
        {
            if (TempData.ContainsKey(SweetAlertMessageKey))
            {
                return;
            }

            TempData[SweetAlertTitleKey] = title;
            TempData[SweetAlertMessageKey] = message;
            TempData[SweetAlertIconKey] = icon;
        }
    }
}
