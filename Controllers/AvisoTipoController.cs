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
    public class AvisoTipoController : Controller
    {
        private readonly Contexto _context;

        public AvisoTipoController(Contexto context)
        {
            _context = context;
        }

        // GET: AvisoTipo
        public async Task<IActionResult> Index()
        {
              return _context.AvisoTipo != null ? 
                          View(await _context.AvisoTipo.ToListAsync()) :
                          Problem("Entity set 'Contexto.AvisoTipo'  is null.");
        }

        // GET: AvisoTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AvisoTipo == null)
            {
                return NotFound();
            }

            var avisoTipoModel = await _context.AvisoTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avisoTipoModel == null)
            {
                return NotFound();
            }

            return View(avisoTipoModel);
        }

        // GET: AvisoTipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AvisoTipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AvisoTipoNome")] AvisoTipoModel avisoTipoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avisoTipoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avisoTipoModel);
        }

        // GET: AvisoTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AvisoTipo == null)
            {
                return NotFound();
            }

            var avisoTipoModel = await _context.AvisoTipo.FindAsync(id);
            if (avisoTipoModel == null)
            {
                return NotFound();
            }
            return View(avisoTipoModel);
        }

        // POST: AvisoTipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AvisoTipoNome")] AvisoTipoModel avisoTipoModel)
        {
            if (id != avisoTipoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avisoTipoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvisoTipoModelExists(avisoTipoModel.Id))
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
            return View(avisoTipoModel);
        }

        // GET: AvisoTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AvisoTipo == null)
            {
                return NotFound();
            }

            var avisoTipoModel = await _context.AvisoTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avisoTipoModel == null)
            {
                return NotFound();
            }

            return View(avisoTipoModel);
        }

        // POST: AvisoTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AvisoTipo == null)
            {
                return Problem("Entity set 'Contexto.AvisoTipo'  is null.");
            }
            var avisoTipoModel = await _context.AvisoTipo.FindAsync(id);
            if (avisoTipoModel != null)
            {
                _context.AvisoTipo.Remove(avisoTipoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvisoTipoModelExists(int id)
        {
          return (_context.AvisoTipo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
