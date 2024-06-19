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
    [Route("api/cidades")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly ClienteContext _context;

        public CidadesController(ClienteContext context)
        {
            _context = context;
        }

        // GET: api/cidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> GetCidades()
        {
            return await _context.Cidades.ToListAsync();
        }

        // GET: api/cidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cidade>> GetCidade(int id)
        {
            var cidade = await _context.Cidades.FindAsync(id);

            if (cidade == null)
            {
                return NotFound();
            }

            return cidade;
        }

        // PUT: api/cidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCidade(int id, Cidade cidade)
        {
            if (id != cidade.CidadeId)
            {
                return BadRequest();
            }

            _context.Entry(cidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(id))
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

        // POST: api/cidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cidade>> PostCidade(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCidade", new { id = cidade.CidadeId }, cidade);
        }

        // DELETE: api/cidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCidade(int id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }

            _context.Cidades.Remove(cidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CidadeExists(int id)
        {
            return _context.Cidades.Any(e => e.CidadeId == id);
        }
    }
}
