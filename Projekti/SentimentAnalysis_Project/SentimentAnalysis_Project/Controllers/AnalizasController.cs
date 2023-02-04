using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SentimentAnalysis_Project.Models;

namespace SentimentAnalysis_Project.Controllers
{
    public class AnalizasController : Controller
    {
        private readonly draftP1Context _context;

        public AnalizasController(draftP1Context context)
        {
            _context = context;
        }

        // GET: Analizas
        public async Task<IActionResult> Index()
        {
            var draftP1Context = _context.Analizas.Include(a => a.IdfeedbackNavigation);
            return View(await draftP1Context.ToListAsync());
        }

        // GET: Analizas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Analizas == null)
            {
                return NotFound();
            }

            var analiza = await _context.Analizas
                .Include(a => a.IdfeedbackNavigation)
                .FirstOrDefaultAsync(m => m.Idanaliza == id);
            if (analiza == null)
            {
                return NotFound();
            }

            return View(analiza);
        }

        // GET: Analizas/Create
        public IActionResult Create()
        {
            ViewData["Idfeedback"] = new SelectList(_context.Feedbacks, "Idfeedback", "Idfeedback");
            return View();
        }

        // POST: Analizas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idanaliza,Rezultati,Idfeedback")] Analiza analiza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analiza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idfeedback"] = new SelectList(_context.Feedbacks, "Idfeedback", "Idfeedback", analiza.Idfeedback);
            return View(analiza);
        }

        // GET: Analizas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Analizas == null)
            {
                return NotFound();
            }

            var analiza = await _context.Analizas.FindAsync(id);
            if (analiza == null)
            {
                return NotFound();
            }
            ViewData["Idfeedback"] = new SelectList(_context.Feedbacks, "Idfeedback", "Idfeedback", analiza.Idfeedback);
            return View(analiza);
        }

        // POST: Analizas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idanaliza,Rezultati,Idfeedback")] Analiza analiza)
        {
            if (id != analiza.Idanaliza)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analiza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalizaExists(analiza.Idanaliza))
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
            ViewData["Idfeedback"] = new SelectList(_context.Feedbacks, "Idfeedback", "Idfeedback", analiza.Idfeedback);
            return View(analiza);
        }

        // GET: Analizas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Analizas == null)
            {
                return NotFound();
            }

            var analiza = await _context.Analizas
                .Include(a => a.IdfeedbackNavigation)
                .FirstOrDefaultAsync(m => m.Idanaliza == id);
            if (analiza == null)
            {
                return NotFound();
            }

            return View(analiza);
        }

        // POST: Analizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Analizas == null)
            {
                return Problem("Entity set 'draftP1Context.Analizas'  is null.");
            }
            var analiza = await _context.Analizas.FindAsync(id);
            if (analiza != null)
            {
                _context.Analizas.Remove(analiza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalizaExists(int id)
        {
          return _context.Analizas.Any(e => e.Idanaliza == id);
        }
    }
}
