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
    public class FabricanteController : Controller
    {
        private readonly Contexto _context;

        public FabricanteController(Contexto context)
        {
            _context = context;
        }

        // GET: Fabricante
        public async Task<IActionResult> Index()
        {
              return _context.Fabricante != null ? 
                          View(await _context.Fabricante.ToListAsync()) :
                          Problem("Entity set 'Contexto.Fabricante'  is null.");
        }

        // GET: Fabricante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fabricante == null)
            {
                return NotFound();
            }

            var fabricanteModel = await _context.Fabricante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fabricanteModel == null)
            {
                return NotFound();
            }

            return View(fabricanteModel);
        }

        // GET: Fabricante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fabricante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FabricanteNome")] FabricanteModel fabricanteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fabricanteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fabricanteModel);
        }

        // GET: Fabricante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fabricante == null)
            {
                return NotFound();
            }

            var fabricanteModel = await _context.Fabricante.FindAsync(id);
            if (fabricanteModel == null)
            {
                return NotFound();
            }
            return View(fabricanteModel);
        }

        // POST: Fabricante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FabricanteNome")] FabricanteModel fabricanteModel)
        {
            if (id != fabricanteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fabricanteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FabricanteModelExists(fabricanteModel.Id))
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
            return View(fabricanteModel);
        }

        // GET: Fabricante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fabricante == null)
            {
                return NotFound();
            }

            var fabricanteModel = await _context.Fabricante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fabricanteModel == null)
            {
                return NotFound();
            }

            return View(fabricanteModel);
        }

        // POST: Fabricante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fabricante == null)
            {
                return Problem("Entity set 'Contexto.Fabricante'  is null.");
            }
            var fabricanteModel = await _context.Fabricante.FindAsync(id);
            if (fabricanteModel != null)
            {
                _context.Fabricante.Remove(fabricanteModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FabricanteModelExists(int id)
        {
          return (_context.Fabricante?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
