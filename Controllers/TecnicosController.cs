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
    public class TecnicosController : Controller
    {
        private readonly Contexto _context;

        public TecnicosController(Contexto context)
        {
            _context = context;
        }

        // GET: Tecnicos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Tecnicos.Include(t => t.TecnicoTipo);
            return View(await contexto.ToListAsync());
        }

        // GET: Tecnicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnicosModel = await _context.Tecnicos
                .Include(t => t.TecnicoTipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnicosModel == null)
            {
                return NotFound();
            }

            return View(tecnicosModel);
        }

        // GET: Tecnicos/Create
        public IActionResult Create()
        {
            ViewData["TecnicoTipoId"] = new SelectList(_context.TecnicoTipo, "Id", "TecnicoTipoDescricao");
            return View();
        }

        // POST: Tecnicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TecnicoNome,TecnicoDatalhes,TecnicoTipoId")] TecnicosModel tecnicosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnicosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TecnicoTipoId"] = new SelectList(_context.TecnicoTipo, "Id", "TecnicoTipoDescricao", tecnicosModel.TecnicoTipoId);
            return View(tecnicosModel);
        }

        // GET: Tecnicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnicosModel = await _context.Tecnicos.FindAsync(id);
            if (tecnicosModel == null)
            {
                return NotFound();
            }
            ViewData["TecnicoTipoId"] = new SelectList(_context.TecnicoTipo, "Id", "TecnicoTipoDescricao", tecnicosModel.TecnicoTipoId);
            return View(tecnicosModel);
        }

        // POST: Tecnicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TecnicoNome,TecnicoDatalhes,TecnicoTipoId")] TecnicosModel tecnicosModel)
        {
            if (id != tecnicosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnicosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicosModelExists(tecnicosModel.Id))
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
            ViewData["TecnicoTipoId"] = new SelectList(_context.TecnicoTipo, "Id", "TecnicoTipoDescricao", tecnicosModel.TecnicoTipoId);
            return View(tecnicosModel);
        }

        // GET: Tecnicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnicosModel = await _context.Tecnicos
                .Include(t => t.TecnicoTipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnicosModel == null)
            {
                return NotFound();
            }

            return View(tecnicosModel);
        }

        // POST: Tecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tecnicos == null)
            {
                return Problem("Entity set 'Contexto.Tecnicos'  is null.");
            }
            var tecnicosModel = await _context.Tecnicos.FindAsync(id);
            if (tecnicosModel != null)
            {
                _context.Tecnicos.Remove(tecnicosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicosModelExists(int id)
        {
          return (_context.Tecnicos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
