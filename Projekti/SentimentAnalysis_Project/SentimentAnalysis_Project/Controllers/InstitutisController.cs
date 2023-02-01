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
    public class InstitutisController : Controller
    {
        private readonly draftP1Context _context;

        public InstitutisController(draftP1Context context)
        {
            _context = context;
        }

        // GET: Institutis
        public async Task<IActionResult> Index()
        {
              return View(await _context.Institutis.ToListAsync());
        }

        // GET: Institutis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Institutis == null)
            {
                return NotFound();
            }

            var instituti = await _context.Institutis
                .FirstOrDefaultAsync(m => m.InstitutiId == id);
            if (instituti == null)
            {
                return NotFound();
            }

            return View(instituti);
        }

        // GET: Institutis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Institutis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstitutiId,Emri,Lokacioni,NrStudenteve,Nrtelefonit")] Instituti instituti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituti);
        }

        // GET: Institutis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Institutis == null)
            {
                return NotFound();
            }

            var instituti = await _context.Institutis.FindAsync(id);
            if (instituti == null)
            {
                return NotFound();
            }
            return View(instituti);
        }

        // POST: Institutis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstitutiId,Emri,Lokacioni,NrStudenteve,Nrtelefonit")] Instituti instituti)
        {
            if (id != instituti.InstitutiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutiExists(instituti.InstitutiId))
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
            return View(instituti);
        }

        // GET: Institutis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Institutis == null)
            {
                return NotFound();
            }

            var instituti = await _context.Institutis
                .FirstOrDefaultAsync(m => m.InstitutiId == id);
            if (instituti == null)
            {
                return NotFound();
            }

            return View(instituti);
        }

        // POST: Institutis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Institutis == null)
            {
                return Problem("Entity set 'draftP1Context.Institutis'  is null.");
            }
            var instituti = await _context.Institutis.FindAsync(id);
            if (instituti != null)
            {
                _context.Institutis.Remove(instituti);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutiExists(int id)
        {
          return _context.Institutis.Any(e => e.InstitutiId == id);
        }
    }
}
