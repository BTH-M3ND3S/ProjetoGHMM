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
    public class CargoController : Controller
    {
        private readonly Contexto _context;

        public CargoController(Contexto context)
        {
            _context = context;
        }

        // GET: Cargo
        public async Task<IActionResult> Index()
        {
              return _context.Cargo != null ? 
                          View(await _context.Cargo.ToListAsync()) :
                          Problem("Entity set 'Contexto.Cargo'  is null.");
        }

        // GET: Cargo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cargo == null)
            {
                return NotFound();
            }

            var cargoModel = await _context.Cargo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargoModel == null)
            {
                return NotFound();
            }

            return View(cargoModel);
        }

        // GET: Cargo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CargoNome")] CargoModel cargoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cargoModel);
        }

        // GET: Cargo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cargo == null)
            {
                return NotFound();
            }

            var cargoModel = await _context.Cargo.FindAsync(id);
            if (cargoModel == null)
            {
                return NotFound();
            }
            return View(cargoModel);
        }

        // POST: Cargo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CargoNome")] CargoModel cargoModel)
        {
            if (id != cargoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoModelExists(cargoModel.Id))
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
            return View(cargoModel);
        }

        // GET: Cargo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cargo == null)
            {
                return NotFound();
            }

            var cargoModel = await _context.Cargo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargoModel == null)
            {
                return NotFound();
            }

            return View(cargoModel);
        }

        // POST: Cargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cargo == null)
            {
                return Problem("Entity set 'Contexto.Cargo'  is null.");
            }
            var cargoModel = await _context.Cargo.FindAsync(id);
            if (cargoModel != null)
            {
                _context.Cargo.Remove(cargoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoModelExists(int id)
        {
          return (_context.Cargo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
