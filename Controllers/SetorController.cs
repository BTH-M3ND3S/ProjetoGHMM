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
    public class SetorController : Controller
    {
        private readonly Contexto _context;

        public SetorController(Contexto context)
        {
            _context = context;
        }

        // GET: Setor
        public async Task<IActionResult> Index()
        {
              return _context.Setor != null ? 
                          View(await _context.Setor.ToListAsync()) :
                          Problem("Entity set 'Contexto.Setor'  is null.");
        }

        // GET: Setor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Setor == null)
            {
                return NotFound();
            }

            var setorModel = await _context.Setor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (setorModel == null)
            {
                return NotFound();
            }

            return View(setorModel);
        }

        // GET: Setor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SetorNome")] SetorModel setorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(setorModel);
        }

        // GET: Setor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Setor == null)
            {
                return NotFound();
            }

            var setorModel = await _context.Setor.FindAsync(id);
            if (setorModel == null)
            {
                return NotFound();
            }
            return View(setorModel);
        }

        // POST: Setor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SetorNome")] SetorModel setorModel)
        {
            if (id != setorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetorModelExists(setorModel.Id))
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
            return View(setorModel);
        }

        // GET: Setor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Setor == null)
            {
                return NotFound();
            }

            var setorModel = await _context.Setor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (setorModel == null)
            {
                return NotFound();
            }

            return View(setorModel);
        }

        // POST: Setor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Setor == null)
            {
                return Problem("Entity set 'Contexto.Setor'  is null.");
            }
            var setorModel = await _context.Setor.FindAsync(id);
            if (setorModel != null)
            {
                _context.Setor.Remove(setorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetorModelExists(int id)
        {
          return (_context.Setor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
