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
    public class RelatorioController : Controller
    {
        private readonly Contexto _context;

        public RelatorioController(Contexto context)
        {
            _context = context;
        }

        // GET: Relatorio
        public async Task<IActionResult> Index()
        {
            var contexto = _context.RelatorioModel.Include(r => r.Funcionario);
            return View(await contexto.ToListAsync());
        }

        // GET: Relatorio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RelatorioModel == null)
            {
                return NotFound();
            }

            var relatorioModel = await _context.RelatorioModel
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioModel == null)
            {
                return NotFound();
            }

            return View(relatorioModel);
        }

        // GET: Relatorio/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "FuncionarioCpf");
            return View();
        }

        // POST: Relatorio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RelatorioConteudo,FuncionarioId")] RelatorioModel relatorioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "FuncionarioCpf", relatorioModel.FuncionarioId);
            return View(relatorioModel);
        }

        // GET: Relatorio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RelatorioModel == null)
            {
                return NotFound();
            }

            var relatorioModel = await _context.RelatorioModel.FindAsync(id);
            if (relatorioModel == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "FuncionarioCpf", relatorioModel.FuncionarioId);
            return View(relatorioModel);
        }

        // POST: Relatorio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RelatorioConteudo,FuncionarioId")] RelatorioModel relatorioModel)
        {
            if (id != relatorioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioModelExists(relatorioModel.Id))
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
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "FuncionarioCpf", relatorioModel.FuncionarioId);
            return View(relatorioModel);
        }

        // GET: Relatorio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RelatorioModel == null)
            {
                return NotFound();
            }

            var relatorioModel = await _context.RelatorioModel
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (relatorioModel == null)
            {
                return NotFound();
            }

            return View(relatorioModel);
        }

        // POST: Relatorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RelatorioModel == null)
            {
                return Problem("Entity set 'Contexto.RelatorioModel'  is null.");
            }
            var relatorioModel = await _context.RelatorioModel.FindAsync(id);
            if (relatorioModel != null)
            {
                _context.RelatorioModel.Remove(relatorioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioModelExists(int id)
        {
          return (_context.RelatorioModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
