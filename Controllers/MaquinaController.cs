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
    public class MaquinaController : Controller
    {
        private readonly Contexto _context;

        public MaquinaController(Contexto context)
        {
            _context = context;
        }

        // GET: Maquina
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Maquina.Include(m => m.Fabricante).Include(m => m.Setor).Include(m => m.TipoMaquina);
            return View(await contexto.ToListAsync());
        }

        // GET: Maquina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maquina == null)
            {
                return NotFound();
            }

            var maquinaModel = await _context.Maquina
                .Include(m => m.Fabricante)
                .Include(m => m.Setor)
                .Include(m => m.TipoMaquina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquinaModel == null)
            {
                return NotFound();
            }

            return View(maquinaModel);
        }

        // GET: Maquina/Create
        public IActionResult Create()
        {
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "FabricanteNome");
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "SetorNome");
            ViewData["TipoMaquinaId"] = new SelectList(_context.TipoMaquina, "Id", "TipoMaquinaNome");
            return View();
        }

        // POST: Maquina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaquinaNome,TipoMaquinaId,SetorId,MaquinaModelo,MaquinaNumeroSerie,FabricanteId,MaquinaDataAquisicao,MaquinaFotoUrl,MaquinaPeso,MaquinaVoltagem")] MaquinaModel maquinaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquinaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "FabricanteNome", maquinaModel.FabricanteId);
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "SetorNome", maquinaModel.SetorId);
            ViewData["TipoMaquinaId"] = new SelectList(_context.TipoMaquina, "Id", "TipoMaquinaNome", maquinaModel.TipoMaquinaId);
            return View(maquinaModel);
        }

        // GET: Maquina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Maquina == null)
            {
                return NotFound();
            }

            var maquinaModel = await _context.Maquina.FindAsync(id);
            if (maquinaModel == null)
            {
                return NotFound();
            }
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "FabricanteNome", maquinaModel.FabricanteId);
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "SetorNome", maquinaModel.SetorId);
            ViewData["TipoMaquinaId"] = new SelectList(_context.TipoMaquina, "Id", "TipoMaquinaNome", maquinaModel.TipoMaquinaId);
            return View(maquinaModel);
        }

        // POST: Maquina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaquinaNome,TipoMaquinaId,SetorId,MaquinaModelo,MaquinaNumeroSerie,FabricanteId,MaquinaDataAquisicao,MaquinaFotoUrl,MaquinaPeso,MaquinaVoltagem")] MaquinaModel maquinaModel)
        {
            if (id != maquinaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquinaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinaModelExists(maquinaModel.Id))
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
            ViewData["FabricanteId"] = new SelectList(_context.Fabricante, "Id", "FabricanteNome", maquinaModel.FabricanteId);
            ViewData["SetorId"] = new SelectList(_context.Setor, "Id", "SetorNome", maquinaModel.SetorId);
            ViewData["TipoMaquinaId"] = new SelectList(_context.TipoMaquina, "Id", "TipoMaquinaNome", maquinaModel.TipoMaquinaId);
            return View(maquinaModel);
        }

        // GET: Maquina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Maquina == null)
            {
                return NotFound();
            }

            var maquinaModel = await _context.Maquina
                .Include(m => m.Fabricante)
                .Include(m => m.Setor)
                .Include(m => m.TipoMaquina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquinaModel == null)
            {
                return NotFound();
            }

            return View(maquinaModel);
        }

        // POST: Maquina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maquina == null)
            {
                return Problem("Entity set 'Contexto.Maquina'  is null.");
            }
            var maquinaModel = await _context.Maquina.FindAsync(id);
            if (maquinaModel != null)
            {
                _context.Maquina.Remove(maquinaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinaModelExists(int id)
        {
          return (_context.Maquina?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
