using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Upd8Clientes_Core.Data;
using Upd8Clientes_Core.Models;

namespace Upd8Clientes_Core.API
{
    [Route("api/estados")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly ClienteContext _context;

        public EstadosController(ClienteContext context)
        {
            _context = context;
        }

        // GET: api/estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            return await _context.Estados.ToListAsync();
        }

        // GET: api/estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
            var estado = await _context.Estados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // PUT: api/estados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, Estado estado)
        {
            if (id != estado.EstadoId)
            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
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

        // POST: api/estados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado estado)
        {
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstado", new { id = estado.EstadoId }, estado);
        }

        // DELETE: api/estados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoExists(int id)
        {
            return _context.Estados.Any(e => e.EstadoId == id);
        }
    }
}
