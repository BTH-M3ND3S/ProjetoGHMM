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
    public class TecnicoTipoController : Controller
    {
        private readonly Contexto _context;

        public TecnicoTipoController(Contexto context)
        {
            _context = context;
        }

        // GET: TecnicoTipo
        public async Task<IActionResult> Index()
        {
              return _context.TecnicoTipo != null ? 
                          View(await _context.TecnicoTipo.ToListAsync()) :
                          Problem("Entity set 'Contexto.TecnicoTipo'  is null.");
        }

        // GET: TecnicoTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TecnicoTipo == null)
            {
                return NotFound();
            }

            var tecnicoTipoModel = await _context.TecnicoTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnicoTipoModel == null)
            {
                return NotFound();
            }

            return View(tecnicoTipoModel);
        }

        // GET: TecnicoTipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TecnicoTipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TecnicoTipoDescricao")] TecnicoTipoModel tecnicoTipoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnicoTipoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tecnicoTipoModel);
        }

        // GET: TecnicoTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TecnicoTipo == null)
            {
                return NotFound();
            }

            var tecnicoTipoModel = await _context.TecnicoTipo.FindAsync(id);
            if (tecnicoTipoModel == null)
            {
                return NotFound();
            }
            return View(tecnicoTipoModel);
        }

        // POST: TecnicoTipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TecnicoTipoDescricao")] TecnicoTipoModel tecnicoTipoModel)
        {
            if (id != tecnicoTipoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnicoTipoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicoTipoModelExists(tecnicoTipoModel.Id))
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
            return View(tecnicoTipoModel);
        }

        // GET: TecnicoTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TecnicoTipo == null)
            {
                return NotFound();
            }

            var tecnicoTipoModel = await _context.TecnicoTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnicoTipoModel == null)
            {
                return NotFound();
            }

            return View(tecnicoTipoModel);
        }

        // POST: TecnicoTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TecnicoTipo == null)
            {
                return Problem("Entity set 'Contexto.TecnicoTipo'  is null.");
            }
            var tecnicoTipoModel = await _context.TecnicoTipo.FindAsync(id);
            if (tecnicoTipoModel != null)
            {
                _context.TecnicoTipo.Remove(tecnicoTipoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicoTipoModelExists(int id)
        {
          return (_context.TecnicoTipo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
