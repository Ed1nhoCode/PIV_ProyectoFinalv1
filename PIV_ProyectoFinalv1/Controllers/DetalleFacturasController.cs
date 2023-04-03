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
    public class DetalleFacturasController : Controller
    {
        private readonly PivPfProyectoFinalv1Context _context;

        public DetalleFacturasController(PivPfProyectoFinalv1Context context)
        {
            _context = context;
        }

        // GET: DetalleFacturas
        public async Task<IActionResult> Index()
        {
            var pivPfProyectoFinalv1Context = _context.DetalleFacturas.Include(d => d.IdFacturaNavigation).Include(d => d.IdProductoNavigation);
            return View(await pivPfProyectoFinalv1Context.ToListAsync());
        }

        // GET: DetalleFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleFacturas == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFacturas
                .Include(d => d.IdFacturaNavigation)
                .Include(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleFact == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Create
        public IActionResult Create()
        {
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "IdFactura", "IdFactura");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto");
            return View();
        }

        // POST: DetalleFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleFact,IdFactura,IdProducto,Cantidad,Precio")] DetalleFactura detalleFactura)
        {

                _context.Add(detalleFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "IdFactura", "IdFactura", detalleFactura.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", detalleFactura.IdProducto);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleFacturas == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFacturas.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "IdFactura", "IdFactura", detalleFactura.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", detalleFactura.IdProducto);
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleFact,IdFactura,IdProducto,Cantidad,Precio")] DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.IdDetalleFact)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaExists(detalleFactura.IdDetalleFact))
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
            ViewData["IdFactura"] = new SelectList(_context.Facturas, "IdFactura", "IdFactura", detalleFactura.IdFactura);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", detalleFactura.IdProducto);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleFacturas == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFacturas
                .Include(d => d.IdFacturaNavigation)
                .Include(d => d.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleFact == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleFacturas == null)
            {
                return Problem("Entity set 'PivPfProyectoFinalv1Context.DetalleFacturas'  is null.");
            }
            var detalleFactura = await _context.DetalleFacturas.FindAsync(id);
            if (detalleFactura != null)
            {
                _context.DetalleFacturas.Remove(detalleFactura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaExists(int id)
        {
          return (_context.DetalleFacturas?.Any(e => e.IdDetalleFact == id)).GetValueOrDefault();
        }
    }
}
