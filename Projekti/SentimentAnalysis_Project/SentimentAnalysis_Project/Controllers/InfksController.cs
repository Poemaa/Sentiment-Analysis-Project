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
    public class InfksController : Controller
    {
        private readonly draftP1Context _context;

        public InfksController(draftP1Context context)
        {
            _context = context;
        }

        // GET: Infks
        public async Task<IActionResult> Index()
        {
            var draftP1Context = _context.Infks.Include(i => i.FakultetiDegaNavigation).Include(i => i.InstitutiEmriNavigation);
            return View(await draftP1Context.ToListAsync());
        }

        // GET: Infks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Infks == null)
            {
                return NotFound();
            }

            var infk = await _context.Infks
                .Include(i => i.FakultetiDegaNavigation)
                .Include(i => i.InstitutiEmriNavigation)
                .FirstOrDefaultAsync(m => m.InstitutiEmri == id);
            if (infk == null)
            {
                return NotFound();
            }

            return View(infk);
        }

        // GET: Infks/Create
        public IActionResult Create()
        {
            ViewData["FakultetiDega"] = new SelectList(_context.Fakultetis, "Dega", "Dega");
            ViewData["InstitutiEmri"] = new SelectList(_context.Institutis, "Emri", "Emri");
            return View();
        }

        // POST: Infks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idinfk,InstitutiEmri,FakultetiDega,Email,StatusiAkredititmit,VitiAkreditimit")] Infk infk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FakultetiDega"] = new SelectList(_context.Fakultetis, "Dega", "Dega", infk.FakultetiDega);
            ViewData["InstitutiEmri"] = new SelectList(_context.Institutis, "Emri", "Emri", infk.InstitutiEmri);
            return View(infk);
        }

        // GET: Infks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Infks == null)
            {
                return NotFound();
            }

            var infk = await _context.Infks.FindAsync(id);
            if (infk == null)
            {
                return NotFound();
            }
            ViewData["FakultetiDega"] = new SelectList(_context.Fakultetis, "Dega", "Dega", infk.FakultetiDega);
            ViewData["InstitutiEmri"] = new SelectList(_context.Institutis, "Emri", "Emri", infk.InstitutiEmri);
            return View(infk);
        }

        // POST: Infks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idinfk,InstitutiEmri,FakultetiDega,Email,StatusiAkredititmit,VitiAkreditimit")] Infk infk)
        {
            if (id != infk.InstitutiEmri)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfkExists(infk.InstitutiEmri))
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
            ViewData["FakultetiDega"] = new SelectList(_context.Fakultetis, "Dega", "Dega", infk.FakultetiDega);
            ViewData["InstitutiEmri"] = new SelectList(_context.Institutis, "Emri", "Emri", infk.InstitutiEmri);
            return View(infk);
        }

        // GET: Infks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Infks == null)
            {
                return NotFound();
            }

            var infk = await _context.Infks
                .Include(i => i.FakultetiDegaNavigation)
                .Include(i => i.InstitutiEmriNavigation)
                .FirstOrDefaultAsync(m => m.InstitutiEmri == id);
            if (infk == null)
            {
                return NotFound();
            }

            return View(infk);
        }

        // POST: Infks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Infks == null)
            {
                return Problem("Entity set 'draftP1Context.Infks'  is null.");
            }
            var infk = await _context.Infks.FindAsync(id);
            if (infk != null)
            {
                _context.Infks.Remove(infk);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfkExists(string id)
        {
          return _context.Infks.Any(e => e.InstitutiEmri == id);
        }
    }
}
