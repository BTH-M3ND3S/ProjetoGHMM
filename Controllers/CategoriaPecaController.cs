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
    public class CategoriaPecaController : Controller
    {
        private readonly Contexto _context;

        public CategoriaPecaController(Contexto context)
        {
            _context = context;
        }

        // GET: CategoriaPeca
        public async Task<IActionResult> Index()
        {
              return _context.CateogriaPeca != null ? 
                          View(await _context.CateogriaPeca.ToListAsync()) :
                          Problem("Entity set 'Contexto.CateogriaPeca'  is null.");
        }

        // GET: CategoriaPeca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CateogriaPeca == null)
            {
                return NotFound();
            }

            var categoriaPecaModel = await _context.CateogriaPeca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaPecaModel == null)
            {
                return NotFound();
            }

            return View(categoriaPecaModel);
        }

        // GET: CategoriaPeca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaPeca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoriaPecaNome")] CategoriaPecaModel categoriaPecaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaPecaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaPecaModel);
        }

        // GET: CategoriaPeca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CateogriaPeca == null)
            {
                return NotFound();
            }

            var categoriaPecaModel = await _context.CateogriaPeca.FindAsync(id);
            if (categoriaPecaModel == null)
            {
                return NotFound();
            }
            return View(categoriaPecaModel);
        }

        // POST: CategoriaPeca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoriaPecaNome")] CategoriaPecaModel categoriaPecaModel)
        {
            if (id != categoriaPecaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaPecaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaPecaModelExists(categoriaPecaModel.Id))
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
            return View(categoriaPecaModel);
        }

        // GET: CategoriaPeca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CateogriaPeca == null)
            {
                return NotFound();
            }

            var categoriaPecaModel = await _context.CateogriaPeca
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaPecaModel == null)
            {
                return NotFound();
            }

            return View(categoriaPecaModel);
        }

        // POST: CategoriaPeca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CateogriaPeca == null)
            {
                return Problem("Entity set 'Contexto.CateogriaPeca'  is null.");
            }
            var categoriaPecaModel = await _context.CateogriaPeca.FindAsync(id);
            if (categoriaPecaModel != null)
            {
                _context.CateogriaPeca.Remove(categoriaPecaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaPecaModelExists(int id)
        {
          return (_context.CateogriaPeca?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
