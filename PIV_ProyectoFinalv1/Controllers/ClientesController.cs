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
    public class ClientesController : Controller
    {
        private readonly PivPfProyectoFinalv1Context _context;

        public ClientesController(PivPfProyectoFinalv1Context context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
              return _context.Clientes != null ? 
                          View(await _context.Clientes.ToListAsync()) :
                          Problem("Entity set 'PivPfProyectoFinalv1Context.Clientes'  is null.");
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,NombreCliente,Correo,Direccion,Telefono")] Cliente cliente)
        {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,NombreCliente,Correo,Direccion,Telefono")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.IdCliente))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'PivPfProyectoFinalv1Context.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Clientes?.Any(e => e.IdCliente == id)).GetValueOrDefault();
        }

        [HttpGet]
        public ActionResult actualizarCliente(int id)
        {
            Cliente c = new Cliente();
            using (_context)
            {
                var cliente = _context.Clientes.Find(id);
                if (cliente != null)
                {
                    c.IdCliente = cliente.IdCliente;
                    c.NombreCliente = cliente.NombreCliente;
                    c.Correo = cliente.Correo;
                    c.Direccion = cliente.Direccion;
                    c.Telefono = cliente.Telefono;
                }
                return View(c);
            }
            
        }
   

        public ActionResult actualizarCliente(Cliente client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(client);
                }

                using (_context)
                {

                    var clientes = _context.Clientes.Find(client.IdCliente);
                    
                    
                    if (clientes != null) {

                        var direccion = clientes.Direccion;
                        var telefono = clientes.Telefono;

                        clientes.NombreCliente = client.NombreCliente;
                        clientes.Correo = client.Correo;
                        clientes.Direccion = direccion;
                        clientes.Telefono = telefono;

                        //db.Entry(per).State = System.Data.Entity.EntityState.Modified;                 

                        _context.Entry(clientes).State = EntityState.Modified;

                        _context.SaveChanges();

                        ViewBag.ValorMensaje = 1;
                        ViewBag.MensajeProceso = "Persona actualizada correctamente";
                    }

         

                }


                return View(client);
            }
            catch (Exception ex)
            {
                ViewBag.ValorMensaje = 0;
                ViewBag.MensajeProceso = "Fallo al actualizar la persona" + ex;
                return View(client);
            }
        }
    }
}
