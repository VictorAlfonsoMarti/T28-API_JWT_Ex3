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
    public class MaquinasRegistradorasController : ControllerBase
    {
        private readonly T28API_JWT_Ex3Context _context;

        public MaquinasRegistradorasController(T28API_JWT_Ex3Context context)
        {
            _context = context;
        }

        // GET: api/MaquinasRegistradoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaquinasRegistradoras>>> GetMaquinasRegistradoras()
        {
            return await _context.MaquinasRegistradoras.ToListAsync();
        }

        // GET: api/MaquinasRegistradoras/5
        [HttpGet("{Codigo}")]
        public async Task<ActionResult<MaquinasRegistradoras>> GetMaquinasRegistradoras(int Codigo)
        {
            var maquinasRegistradoras = await _context.MaquinasRegistradoras.FindAsync(Codigo);

            if (maquinasRegistradoras == null)
            {
                return NotFound();
            }

            return maquinasRegistradoras;
        }

        // PUT: api/MaquinasRegistradoras/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{Codigo}")]
        public async Task<IActionResult> PutMaquinasRegistradoras(int Codigo, MaquinasRegistradoras maquinasRegistradoras)
        {
            if (Codigo != maquinasRegistradoras.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(maquinasRegistradoras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaquinasRegistradorasExists(Codigo))
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

        // POST: api/MaquinasRegistradoras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaquinasRegistradoras>> PostMaquinasRegistradoras(MaquinasRegistradoras maquinasRegistradoras)
        {
            _context.MaquinasRegistradoras.Add(maquinasRegistradoras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaquinasRegistradoras", new { Codigo = maquinasRegistradoras.Codigo }, maquinasRegistradoras);
        }

        // DELETE: api/MaquinasRegistradoras/5
        [HttpDelete("{Codigo}")]
        public async Task<ActionResult<MaquinasRegistradoras>> DeleteMaquinasRegistradoras(int Codigo)
        {
            var maquinasRegistradoras = await _context.MaquinasRegistradoras.FindAsync(Codigo);
            if (maquinasRegistradoras == null)
            {
                return NotFound();
            }

            _context.MaquinasRegistradoras.Remove(maquinasRegistradoras);
            await _context.SaveChangesAsync();

            return maquinasRegistradoras;
        }

        private bool MaquinasRegistradorasExists(int Codigo)
        {
            return _context.MaquinasRegistradoras.Any(e => e.Codigo == Codigo);
        }
    }
}
