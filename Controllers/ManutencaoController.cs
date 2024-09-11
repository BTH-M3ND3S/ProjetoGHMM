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
    public class ManutencaoController : Controller
    {
        private readonly Contexto _context;

        public ManutencaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Manutencao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Manutencao.Include(m => m.TipoManutencao);
            return View(await contexto.ToListAsync());
        }

        // GET: Manutencao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Manutencao == null)
            {
                return NotFound();
            }

            var manutencaoModel = await _context.Manutencao
                .Include(m => m.TipoManutencao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manutencaoModel == null)
            {
                return NotFound();
            }

            return View(manutencaoModel);
        }

        // GET: Manutencao/Create
        public IActionResult Create()
        {
            ViewData["TipoManutencaoId"] = new SelectList(_context.TipoManutencao, "Id", "TipoManutencaoNome");
            return View();
        }

        // POST: Manutencao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoManutencaoId,ManutencaoData,ManutencaoDescricao,ManutencaoCusto")] ManutencaoModel manutencaoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manutencaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoManutencaoId"] = new SelectList(_context.TipoManutencao, "Id", "TipoManutencaoNome", manutencaoModel.TipoManutencaoId);
            return View(manutencaoModel);
        }

        // GET: Manutencao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Manutencao == null)
            {
                return NotFound();
            }

            var manutencaoModel = await _context.Manutencao.FindAsync(id);
            if (manutencaoModel == null)
            {
                return NotFound();
            }
            ViewData["TipoManutencaoId"] = new SelectList(_context.TipoManutencao, "Id", "TipoManutencaoNome", manutencaoModel.TipoManutencaoId);
            return View(manutencaoModel);
        }

        // POST: Manutencao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoManutencaoId,ManutencaoData,ManutencaoDescricao,ManutencaoCusto")] ManutencaoModel manutencaoModel)
        {
            if (id != manutencaoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manutencaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManutencaoModelExists(manutencaoModel.Id))
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
            ViewData["TipoManutencaoId"] = new SelectList(_context.TipoManutencao, "Id", "TipoManutencaoNome", manutencaoModel.TipoManutencaoId);
            return View(manutencaoModel);
        }

        // GET: Manutencao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Manutencao == null)
            {
                return NotFound();
            }

            var manutencaoModel = await _context.Manutencao
                .Include(m => m.TipoManutencao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manutencaoModel == null)
            {
                return NotFound();
            }

            return View(manutencaoModel);
        }

        // POST: Manutencao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Manutencao == null)
            {
                return Problem("Entity set 'Contexto.Manutencao'  is null.");
            }
            var manutencaoModel = await _context.Manutencao.FindAsync(id);
            if (manutencaoModel != null)
            {
                _context.Manutencao.Remove(manutencaoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManutencaoModelExists(int id)
        {
          return (_context.Manutencao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
