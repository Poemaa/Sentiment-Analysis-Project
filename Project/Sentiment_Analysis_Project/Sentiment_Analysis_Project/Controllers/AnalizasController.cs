using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sentiment_Analysis_Project.Models;

namespace Sentiment_Analysis_Project.Controllers
{
    public class AnalizasController : Controller
    {
        private readonly DataContext _context;

        public AnalizasController(DataContext context)
        {
            _context = context;
        }

        // GET: Analizas
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Analizas.Include(a => a.Feedback);
            return View(await dataContext.ToListAsync());
        }

        // GET: Analizas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Analizas == null)
            {
                return NotFound();
            }

            var analiza = await _context.Analizas
                .Include(a => a.Feedback)
                .FirstOrDefaultAsync(m => m.AnalizaId == id);
            if (analiza == null)
            {
                return NotFound();
            }

            return View(analiza);
        }

        // GET: Analizas/Create
        public IActionResult Create()
        {
            ViewData["FeedbackId"] = new SelectList(_context.Feedbakcs, "FeedbackId", "FeedbackId");
            return View();
        }

        // POST: Analizas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnalizaId,Rezultati,FeedbackId")] Analiza analiza)
        {
         
                _context.Add(analiza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["FeedbackId"] = new SelectList(_context.Feedbakcs, "FeedbackId", "FeedbackId", analiza.FeedbackId);
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
            ViewData["FeedbackId"] = new SelectList(_context.Feedbakcs, "FeedbackId", "FeedbackId", analiza.FeedbackId);
            return View(analiza);
        }

        // POST: Analizas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnalizaId,Rezultati,FeedbackId")] Analiza analiza)
        {
            if (id != analiza.AnalizaId)
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
                    if (!AnalizaExists(analiza.AnalizaId))
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
            ViewData["FeedbackId"] = new SelectList(_context.Feedbakcs, "FeedbackId", "FeedbackId", analiza.FeedbackId);
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
                .Include(a => a.Feedback)
                .FirstOrDefaultAsync(m => m.AnalizaId == id);
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
                return Problem("Entity set 'DataContext.Analizas'  is null.");
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
          return _context.Analizas.Any(e => e.AnalizaId == id);
        }
    }
}
