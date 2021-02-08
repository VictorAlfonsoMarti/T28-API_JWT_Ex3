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
    public class CajerosController : ControllerBase
    {
        private readonly T28API_JWT_Ex3Context _context;

        public CajerosController(T28API_JWT_Ex3Context context)
        {
            _context = context;
        }

        // GET: api/Cajeros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cajeros>>> GetCajeros()
        {
            return await _context.Cajeros.ToListAsync();
        }

        // GET: api/Cajeros/5
        [HttpGet("{Codigo}")]
        public async Task<ActionResult<Cajeros>> GetCajeros(int Codigo)
        {
            var cajeros = await _context.Cajeros.FindAsync(Codigo);

            if (cajeros == null)
            {
                return NotFound();
            }

            return cajeros;
        }

        // PUT: api/Cajeros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{Codigo}")]
        public async Task<IActionResult> PutCajeros(int Codigo, Cajeros cajeros)
        {
            if (Codigo != cajeros.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(cajeros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CajerosExists(Codigo))
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

        // POST: api/Cajeros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cajeros>> PostCajeros(Cajeros cajeros)
        {
            _context.Cajeros.Add(cajeros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCajeros", new { Codigo = cajeros.Codigo }, cajeros);
        }

        // DELETE: api/Cajeros/5
        [HttpDelete("{Codigo}")]
        public async Task<ActionResult<Cajeros>> DeleteCajeros(int Codigo)
        {
            var cajeros = await _context.Cajeros.FindAsync(Codigo);
            if (cajeros == null)
            {
                return NotFound();
            }

            _context.Cajeros.Remove(cajeros);
            await _context.SaveChangesAsync();

            return cajeros;
        }

        private bool CajerosExists(int Codigo)
        {
            return _context.Cajeros.Any(e => e.Codigo == Codigo);
        }
    }
}
