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
    public class ProductosController : ControllerBase
    {
        private readonly T28API_JWT_Ex3Context _context;

        public ProductosController(T28API_JWT_Ex3Context context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productos/5
        [HttpGet("{Codigo}")]
        public async Task<ActionResult<Productos>> GetProductos(int Codigo)
        {
            var productos = await _context.Productos.FindAsync(Codigo);

            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{Codigo}")]
        public async Task<IActionResult> PutProductos(int Codigo, Productos productos)
        {
            if (Codigo != productos.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(Codigo))
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

        // POST: api/Productos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
            _context.Productos.Add(productos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductos", new { Codigo = productos.Codigo }, productos);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{Codigo}")]
        public async Task<ActionResult<Productos>> DeleteProductos(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();

            return productos;
        }

        private bool ProductosExists(int Codigo)
        {
            return _context.Productos.Any(e => e.Codigo == Codigo);
        }
    }
}
