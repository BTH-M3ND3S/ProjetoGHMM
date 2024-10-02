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
    public class TecnicoUsuarioController : Controller
    {
        private readonly Contexto _context;

        public TecnicoUsuarioController(Contexto context)
        {
            _context = context;
        }

        // GET: TecnicoUsuario
        public async Task<IActionResult> Index()
        {
            var contexto = _context.TecnicoUsuario.Include(t => t.Tecnicos).Include(t => t.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: TecnicoUsuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TecnicoUsuario == null)
            {
                return NotFound();
            }

            var tecnicoUsuarioModel = await _context.TecnicoUsuario
                .Include(t => t.Tecnicos)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnicoUsuarioModel == null)
            {
                return NotFound();
            }

            return View(tecnicoUsuarioModel);
        }

        // GET: TecnicoUsuario/Create
        public IActionResult Create()
        {
            ViewData["TecnicosId"] = new SelectList(_context.Tecnicos, "Id", "TecnicoNome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioCpf");
            return View();
        }

        // POST: TecnicoUsuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TecnicosId,UsuarioId")] TecnicoUsuarioModel tecnicoUsuarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnicoUsuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TecnicosId"] = new SelectList(_context.Tecnicos, "Id", "TecnicoNome", tecnicoUsuarioModel.TecnicosId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioCpf", tecnicoUsuarioModel.UsuarioId);
            return View(tecnicoUsuarioModel);
        }

        // GET: TecnicoUsuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TecnicoUsuario == null)
            {
                return NotFound();
            }

            var tecnicoUsuarioModel = await _context.TecnicoUsuario.FindAsync(id);
            if (tecnicoUsuarioModel == null)
            {
                return NotFound();
            }
            ViewData["TecnicosId"] = new SelectList(_context.Tecnicos, "Id", "TecnicoNome", tecnicoUsuarioModel.TecnicosId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioCpf", tecnicoUsuarioModel.UsuarioId);
            return View(tecnicoUsuarioModel);
        }

        // POST: TecnicoUsuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TecnicosId,UsuarioId")] TecnicoUsuarioModel tecnicoUsuarioModel)
        {
            if (id != tecnicoUsuarioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnicoUsuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicoUsuarioModelExists(tecnicoUsuarioModel.Id))
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
            ViewData["TecnicosId"] = new SelectList(_context.Tecnicos, "Id", "TecnicoNome", tecnicoUsuarioModel.TecnicosId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioCpf", tecnicoUsuarioModel.UsuarioId);
            return View(tecnicoUsuarioModel);
        }

        // GET: TecnicoUsuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TecnicoUsuario == null)
            {
                return NotFound();
            }

            var tecnicoUsuarioModel = await _context.TecnicoUsuario
                .Include(t => t.Tecnicos)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnicoUsuarioModel == null)
            {
                return NotFound();
            }

            return View(tecnicoUsuarioModel);
        }

        // POST: TecnicoUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TecnicoUsuario == null)
            {
                return Problem("Entity set 'Contexto.TecnicoUsuario'  is null.");
            }
            var tecnicoUsuarioModel = await _context.TecnicoUsuario.FindAsync(id);
            if (tecnicoUsuarioModel != null)
            {
                _context.TecnicoUsuario.Remove(tecnicoUsuarioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicoUsuarioModelExists(int id)
        {
          return (_context.TecnicoUsuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
