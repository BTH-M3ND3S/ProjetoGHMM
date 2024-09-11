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
    public class TipoManutencaoController : Controller
    {
        private readonly Contexto _context;

        public TipoManutencaoController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoManutencao
        public async Task<IActionResult> Index()
        {
              return _context.TipoManutencao != null ? 
                          View(await _context.TipoManutencao.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoManutencao'  is null.");
        }

        // GET: TipoManutencao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoManutencao == null)
            {
                return NotFound();
            }

            var tipoManutencaoModel = await _context.TipoManutencao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoManutencaoModel == null)
            {
                return NotFound();
            }

            return View(tipoManutencaoModel);
        }

        // GET: TipoManutencao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoManutencao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoManutencaoNome")] TipoManutencaoModel tipoManutencaoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoManutencaoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoManutencaoModel);
        }

        // GET: TipoManutencao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoManutencao == null)
            {
                return NotFound();
            }

            var tipoManutencaoModel = await _context.TipoManutencao.FindAsync(id);
            if (tipoManutencaoModel == null)
            {
                return NotFound();
            }
            return View(tipoManutencaoModel);
        }

        // POST: TipoManutencao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoManutencaoNome")] TipoManutencaoModel tipoManutencaoModel)
        {
            if (id != tipoManutencaoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoManutencaoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoManutencaoModelExists(tipoManutencaoModel.Id))
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
            return View(tipoManutencaoModel);
        }

        // GET: TipoManutencao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoManutencao == null)
            {
                return NotFound();
            }

            var tipoManutencaoModel = await _context.TipoManutencao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoManutencaoModel == null)
            {
                return NotFound();
            }

            return View(tipoManutencaoModel);
        }

        // POST: TipoManutencao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoManutencao == null)
            {
                return Problem("Entity set 'Contexto.TipoManutencao'  is null.");
            }
            var tipoManutencaoModel = await _context.TipoManutencao.FindAsync(id);
            if (tipoManutencaoModel != null)
            {
                _context.TipoManutencao.Remove(tipoManutencaoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoManutencaoModelExists(int id)
        {
          return (_context.TipoManutencao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
