using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGHMM.Models;

namespace SistemaGHMM.Controllers
{
    public class ManutencaoEPecasController : Controller
    {
        private readonly Contexto _context;

        public ManutencaoEPecasController(Contexto context)
        {
            _context = context;
        }

        // GET: ManutencaoEPecas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.ManutencaoEPecas.Include(m => m.Manutencao).Include(m => m.Peca);
            return View(await contexto.ToListAsync());
        }

        // GET: ManutencaoEPecas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ManutencaoEPecas == null)
            {
                return NotFound();
            }

            var manutencaoEPecasModel = await _context.ManutencaoEPecas
                .Include(m => m.Manutencao)
                .Include(m => m.Peca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manutencaoEPecasModel == null)
            {
                return NotFound();
            }

            return View(manutencaoEPecasModel);
        }

        // GET: ManutencaoEPecas/Create
        public IActionResult Create()
        {
            ViewData["ManutencaoId"] = new SelectList(_context.Manutencao, "Id", "ManutencaoDescricao");
            ViewData["PecaId"] = new SelectList(_context.Peca, "Id", "PecaNome");
            return View();
        }

        // POST: ManutencaoEPecas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManutencaoId,PecaId")] ManutencaoEPecasModel manutencaoEPecasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manutencaoEPecasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManutencaoId"] = new SelectList(_context.Manutencao, "Id", "ManutencaoDescricao", manutencaoEPecasModel.ManutencaoId);
            ViewData["PecaId"] = new SelectList(_context.Peca, "Id", "PecaNome", manutencaoEPecasModel.PecaId);
            return View(manutencaoEPecasModel);
        }

        // GET: ManutencaoEPecas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ManutencaoEPecas == null)
            {
                return NotFound();
            }

            var manutencaoEPecasModel = await _context.ManutencaoEPecas.FindAsync(id);
            if (manutencaoEPecasModel == null)
            {
                return NotFound();
            }
            ViewData["ManutencaoId"] = new SelectList(_context.Manutencao, "Id", "ManutencaoDescricao", manutencaoEPecasModel.ManutencaoId);
            ViewData["PecaId"] = new SelectList(_context.Peca, "Id", "PecaNome", manutencaoEPecasModel.PecaId);
            return View(manutencaoEPecasModel);
        }

        // POST: ManutencaoEPecas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManutencaoId,PecaId")] ManutencaoEPecasModel manutencaoEPecasModel)
        {
            if (id != manutencaoEPecasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manutencaoEPecasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManutencaoEPecasModelExists(manutencaoEPecasModel.Id))
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
            ViewData["ManutencaoId"] = new SelectList(_context.Manutencao, "Id", "ManutencaoDescricao", manutencaoEPecasModel.ManutencaoId);
            ViewData["PecaId"] = new SelectList(_context.Peca, "Id", "PecaNome", manutencaoEPecasModel.PecaId);
            return View(manutencaoEPecasModel);
        }

        // GET: ManutencaoEPecas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ManutencaoEPecas == null)
            {
                return NotFound();
            }

            var manutencaoEPecasModel = await _context.ManutencaoEPecas
                .Include(m => m.Manutencao)
                .Include(m => m.Peca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manutencaoEPecasModel == null)
            {
                return NotFound();
            }

            return View(manutencaoEPecasModel);
        }

        // POST: ManutencaoEPecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ManutencaoEPecas == null)
            {
                return Problem("Entity set 'Contexto.ManutencaoEPecas'  is null.");
            }
            var manutencaoEPecasModel = await _context.ManutencaoEPecas.FindAsync(id);
            if (manutencaoEPecasModel != null)
            {
                _context.ManutencaoEPecas.Remove(manutencaoEPecasModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManutencaoEPecasModelExists(int id)
        {
          return (_context.ManutencaoEPecas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
