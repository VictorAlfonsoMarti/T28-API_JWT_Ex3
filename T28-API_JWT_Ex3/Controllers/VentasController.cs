using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T28_API_JWT_Ex3.Models;

namespace T28_API_JWT_Ex3.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly T28API_JWT_Ex3Context _context;

        public VentasController(T28API_JWT_Ex3Context context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVenta()
        {
            return await _context.Venta.ToListAsync();
        }

        // GET: api/Ventas/5:4:3
        [HttpGet("{CodigoCajero}:{CodigoMaquina}:{CodigoProducto}")]
        public async Task<ActionResult<Venta>> GetVenta(int CodigoCajero, int CodigoMaquina, int CodigoProducto)
        {
            var venta = await _context.Venta.FindAsync(CodigoCajero, CodigoMaquina, CodigoProducto);

            if (venta == null)
            {
                return NotFound();
            }

            return venta;
        }

        // PUT: api/Ventas/5:4:3
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{CodigoCajero}:{CodigoMaquina}:{CodigoProducto}")]
        public async Task<IActionResult> PutVenta(int CodigoCajero, int CodigoMaquina, int CodigoProducto, Venta venta)
        {
            if (CodigoCajero != venta.Cajero && CodigoMaquina != venta.Maquina && CodigoProducto != venta.Producto)
            {
                return BadRequest();
            }

            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaCodigoExists(CodigoCajero) || !VentaMaquinaExists(CodigoMaquina) || !VentaProductoExists(CodigoProducto))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ventas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            _context.Venta.Add(venta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VentaCodigoExists(venta.Cajero) && VentaMaquinaExists(venta.Maquina) && VentaProductoExists(venta.Producto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVenta", new { Codigo = venta.Cajero }, venta);
        }

        // DELETE: api/Ventas/5:4:3
        [HttpDelete("{CodigoCajero}:{CodigoMaquina}:{CodigoProducto}")]
        public async Task<ActionResult<Venta>> DeleteVenta(int CodigoCajero, int CodigoMaquina, int CodigoProducto)
        {
            var venta = await _context.Venta.FindAsync(CodigoCajero, CodigoMaquina, CodigoProducto);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Venta.Remove(venta);
            await _context.SaveChangesAsync();

            return venta;
        }

        private bool VentaCodigoExists(int Codigo)
        {
            return _context.Venta.Any(e => e.Cajero == Codigo);
        }
        private bool VentaMaquinaExists(int Codigo)
        {
            return _context.Venta.Any(e => e.Maquina == Codigo);
        }
        private bool VentaProductoExists(int Codigo)
        {
            return _context.Venta.Any(e => e.Producto == Codigo);
        }
    }
}
