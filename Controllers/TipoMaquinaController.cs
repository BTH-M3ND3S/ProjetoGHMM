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
    public class TipoMaquinaController : Controller
    {
        private readonly Contexto _context;

        public TipoMaquinaController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoMaquina
        public async Task<IActionResult> Index()
        {
              return _context.TipoMaquina != null ? 
                          View(await _context.TipoMaquina.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoMaquina'  is null.");
        }

        // GET: TipoMaquina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoMaquina == null)
            {
                return NotFound();
            }

            var tipoMaquinaModel = await _context.TipoMaquina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMaquinaModel == null)
            {
                return NotFound();
            }

            return View(tipoMaquinaModel);
        }

        // GET: TipoMaquina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMaquina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoMaquinaNome")] TipoMaquinaModel tipoMaquinaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMaquinaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMaquinaModel);
        }

        // GET: TipoMaquina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoMaquina == null)
            {
                return NotFound();
            }

            var tipoMaquinaModel = await _context.TipoMaquina.FindAsync(id);
            if (tipoMaquinaModel == null)
            {
                return NotFound();
            }
            return View(tipoMaquinaModel);
        }

        // POST: TipoMaquina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoMaquinaNome")] TipoMaquinaModel tipoMaquinaModel)
        {
            if (id != tipoMaquinaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMaquinaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMaquinaModelExists(tipoMaquinaModel.Id))
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
            return View(tipoMaquinaModel);
        }

        // GET: TipoMaquina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoMaquina == null)
            {
                return NotFound();
            }

            var tipoMaquinaModel = await _context.TipoMaquina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMaquinaModel == null)
            {
                return NotFound();
            }

            return View(tipoMaquinaModel);
        }

        // POST: TipoMaquina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoMaquina == null)
            {
                return Problem("Entity set 'Contexto.TipoMaquina'  is null.");
            }
            var tipoMaquinaModel = await _context.TipoMaquina.FindAsync(id);
            if (tipoMaquinaModel != null)
            {
                _context.TipoMaquina.Remove(tipoMaquinaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMaquinaModelExists(int id)
        {
          return (_context.TipoMaquina?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
