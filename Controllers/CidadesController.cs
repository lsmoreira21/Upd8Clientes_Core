using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Upd8Clientes_Core.Data;
using Upd8Clientes_Core.Models;

namespace Upd8Clientes_Core.Controllers
{
    public class CidadesController : Controller
    {
        private readonly ClienteContext _context;

        public CidadesController(ClienteContext context)
        {
            _context = context;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            var clienteContext = _context.Cidades.Include(c => c.Estado);
            return View(await clienteContext.ToListAsync());
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.CidadeId == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome");
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CidadeId,Nome,EstadoId")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome", cidade.EstadoId);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome", cidade.EstadoId);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CidadeId,Nome,EstadoId")] Cidade cidade)
        {
            if (id != cidade.CidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.CidadeId))
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
            ViewData["EstadoId"] = new SelectList(_context.Estados, "EstadoId", "Nome", cidade.EstadoId);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.CidadeId == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade != null)
            {
                _context.Cidades.Remove(cidade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeExists(int id)
        {
            return _context.Cidades.Any(e => e.CidadeId == id);
        }
    }
}
