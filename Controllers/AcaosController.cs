using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaProjetos1._3.Data;
using SistemaProjetos1._3.Models;

namespace SistemaProjetos1._3.Controllers
{
    [Authorize]
    public class AcaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Acaos
        public async Task<IActionResult> Index()
        {
              return _context.Acao != null ? 
                          View(await _context.Acao.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Acao'  is null.");
        }

        // GET: Acaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Acao == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao
                .FirstOrDefaultAsync(m => m.IdAcao == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        // GET: Acaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAcao,IdProjeto,NomeAcao,DescricaoAcao,IdUsuario")] Acao acao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acao);
        }

        // GET: Acaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Acao == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao.FindAsync(id);
            if (acao == null)
            {
                return NotFound();
            }
            return View(acao);
        }

        // POST: Acaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAcao,IdProjeto,NomeAcao,DescricaoAcao,IdUsuario")] Acao acao)
        {
            if (id != acao.IdAcao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcaoExists(acao.IdAcao))
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
            return View(acao);
        }

        // GET: Acaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Acao == null)
            {
                return NotFound();
            }

            var acao = await _context.Acao
                .FirstOrDefaultAsync(m => m.IdAcao == id);
            if (acao == null)
            {
                return NotFound();
            }

            return View(acao);
        }

        // POST: Acaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Acao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Acao'  is null.");
            }
            var acao = await _context.Acao.FindAsync(id);
            if (acao != null)
            {
                _context.Acao.Remove(acao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcaoExists(int id)
        {
          return (_context.Acao?.Any(e => e.IdAcao == id)).GetValueOrDefault();
        }
    }
}
