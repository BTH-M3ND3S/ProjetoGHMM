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
    public class AvisoController : Controller
    {
        private readonly Contexto _context;

        public AvisoController(Contexto context)
        {
            _context = context;
        }

        // GET: Aviso
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Aviso.Include(a => a.AvisoTipo).Include(a => a.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Aviso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aviso == null)
            {
                return NotFound();
            }

            var avisoModel = await _context.Aviso
                .Include(a => a.AvisoTipo)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avisoModel == null)
            {
                return NotFound();
            }

            return View(avisoModel);
        }

        // GET: Aviso/Create
        public IActionResult Create()
        {
            ViewData["AvisoTipoId"] = new SelectList(_context.AvisoTipo, "Id", "AvisoTipoNome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioCpf");
            return View();
        }

        // POST: Aviso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AvisoConteudo,AvisoVisto,UsuarioId,AvisoTipoId")] AvisoModel avisoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avisoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AvisoTipoId"] = new SelectList(_context.AvisoTipo, "Id", "AvisoTipoNome", avisoModel.AvisoTipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioCpf", avisoModel.UsuarioId);
            return View(avisoModel);
        }

        // GET: Aviso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aviso == null)
            {
                return NotFound();
            }

            var avisoModel = await _context.Aviso.FindAsync(id);
            if (avisoModel == null)
            {
                return NotFound();
            }
            ViewData["AvisoTipoId"] = new SelectList(_context.AvisoTipo, "Id", "AvisoTipoNome", avisoModel.AvisoTipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioCpf", avisoModel.UsuarioId);
            return View(avisoModel);
        }

        // POST: Aviso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AvisoConteudo,AvisoVisto,UsuarioId,AvisoTipoId")] AvisoModel avisoModel)
        {
            if (id != avisoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avisoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvisoModelExists(avisoModel.Id))
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
            ViewData["AvisoTipoId"] = new SelectList(_context.AvisoTipo, "Id", "AvisoTipoNome", avisoModel.AvisoTipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "UsuarioCpf", avisoModel.UsuarioId);
            return View(avisoModel);
        }

        // GET: Aviso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aviso == null)
            {
                return NotFound();
            }

            var avisoModel = await _context.Aviso
                .Include(a => a.AvisoTipo)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avisoModel == null)
            {
                return NotFound();
            }

            return View(avisoModel);
        }

        // POST: Aviso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aviso == null)
            {
                return Problem("Entity set 'Contexto.Aviso'  is null.");
            }
            var avisoModel = await _context.Aviso.FindAsync(id);
            if (avisoModel != null)
            {
                _context.Aviso.Remove(avisoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvisoModelExists(int id)
        {
          return (_context.Aviso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
