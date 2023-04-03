using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIV_ProyectoFinalv1.Models;

namespace PIV_ProyectoFinalv1.Controllers
{
    public class ModoPagosController : Controller
    {
        private readonly PivPfProyectoFinalv1Context _context;

        public ModoPagosController(PivPfProyectoFinalv1Context context)
        {
            _context = context;
        }

        // GET: ModoPagos
        public async Task<IActionResult> Index()
        {
              return _context.ModoPagos != null ? 
                          View(await _context.ModoPagos.ToListAsync()) :
                          Problem("Entity set 'PivPfProyectoFinalv1Context.ModoPagos'  is null.");
        }

        // GET: ModoPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ModoPagos == null)
            {
                return NotFound();
            }

            var modoPago = await _context.ModoPagos
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (modoPago == null)
            {
                return NotFound();
            }

            return View(modoPago);
        }

        // GET: ModoPagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModoPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPago,TipoPago")] ModoPago modoPago)
        {

                _context.Add(modoPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(modoPago);
        }

        // GET: ModoPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ModoPagos == null)
            {
                return NotFound();
            }

            var modoPago = await _context.ModoPagos.FindAsync(id);
            if (modoPago == null)
            {
                return NotFound();
            }
            return View(modoPago);
        }

        // POST: ModoPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPago,TipoPago")] ModoPago modoPago)
        {
            if (id != modoPago.IdPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModoPagoExists(modoPago.IdPago))
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
            return View(modoPago);
        }

        // GET: ModoPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ModoPagos == null)
            {
                return NotFound();
            }

            var modoPago = await _context.ModoPagos
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (modoPago == null)
            {
                return NotFound();
            }

            return View(modoPago);
        }

        // POST: ModoPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ModoPagos == null)
            {
                return Problem("Entity set 'PivPfProyectoFinalv1Context.ModoPagos'  is null.");
            }
            var modoPago = await _context.ModoPagos.FindAsync(id);
            if (modoPago != null)
            {
                _context.ModoPagos.Remove(modoPago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModoPagoExists(int id)
        {
          return (_context.ModoPagos?.Any(e => e.IdPago == id)).GetValueOrDefault();
        }
    }
}
