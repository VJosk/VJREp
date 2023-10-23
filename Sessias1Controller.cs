using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASp_Yank.Data;
using ASp_Yank.Models;

namespace ASp_Yank.Controllers
{
    public class Sessias1Controller : Controller
    {
        private readonly ASp_YankContext _context;

        public Sessias1Controller(ASp_YankContext context)
        {
            _context = context;
        }

        // GET: Sessias1
        public async Task<IActionResult> Index()
        {
              return _context.Sessia != null ? 
                          View(await _context.Sessia.ToListAsync()) :
                          Problem("Entity set 'ASp_YankContext.Sessia'  is null.");
        }

        // GET: Sessias1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sessia == null)
            {
                return NotFound();
            }

            var sessia = await _context.Sessia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessia == null)
            {
                return NotFound();
            }

            return View(sessia);
        }

        // GET: Sessias1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sessias1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudId,Type,Русский,Английский,Физика,Математика,Физкультура,Обществознание,История")] Sessia sessia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sessia);
        }

        // GET: Sessias1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sessia == null)
            {
                return NotFound();
            }

            var sessia = await _context.Sessia.FindAsync(id);
            if (sessia == null)
            {
                return NotFound();
            }
            return View(sessia);
        }

        // POST: Sessias1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudId,Type,Русский,Английский,Физика,Математика,Физкультура,Обществознание,История")] Sessia sessia)
        {
            if (id != sessia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessiaExists(sessia.Id))
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
            return View(sessia);
        }

        // GET: Sessias1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sessia == null)
            {
                return NotFound();
            }

            var sessia = await _context.Sessia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessia == null)
            {
                return NotFound();
            }

            return View(sessia);
        }

        // POST: Sessias1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sessia == null)
            {
                return Problem("Entity set 'ASp_YankContext.Sessia'  is null.");
            }
            var sessia = await _context.Sessia.FindAsync(id);
            if (sessia != null)
            {
                _context.Sessia.Remove(sessia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessiaExists(int id)
        {
          return (_context.Sessia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
