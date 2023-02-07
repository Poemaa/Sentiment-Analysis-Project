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
    public class InfksController : Controller
    {
        private readonly DataContext _context;

        public InfksController(DataContext context)
        {
            _context = context;
        }

        // GET: Infks
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Infks.Include(i => i.Fakulteti).Include(i => i.Instituti);
            return View(await dataContext.ToListAsync());
        }

        // GET: Infks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Infks == null)
            {
                return NotFound();
            }

            var infk = await _context.Infks
                .Include(i => i.Fakulteti)
                .Include(i => i.Instituti)
                .FirstOrDefaultAsync(m => m.InfkId == id);
            if (infk == null)
            {
                return NotFound();
            }

            return View(infk);
        }

        // GET: Infks/Create
        public IActionResult Create()
        {
            ViewData["FakultetiId"] = new SelectList(_context.Fakultetis, "FakultetiId", "FakultetiId");
            ViewData["InstitutiId"] = new SelectList(_context.Institutis, "InstitutiId", "InstitutiId");
            return View();
        }

        // POST: Infks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InfkId,FakultetiId,InstitutiId,Email,StatusiAkredititmit,VitiAkreditimit")] Infk infk)
        {
            
                _context.Add(infk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["FakultetiId"] = new SelectList(_context.Fakultetis, "FakultetiId", "FakultetiId", infk.FakultetiId);
            ViewData["InstitutiId"] = new SelectList(_context.Institutis, "InstitutiId", "InstitutiId", infk.InstitutiId);
            return View(infk);
        }

        // GET: Infks/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["FakultetiId"] = new SelectList(_context.Fakultetis, "FakultetiId", "FakultetiId", infk.FakultetiId);
            ViewData["InstitutiId"] = new SelectList(_context.Institutis, "InstitutiId", "InstitutiId", infk.InstitutiId);
            return View(infk);
        }

        // POST: Infks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InfkId,FakultetiId,InstitutiId,Email,StatusiAkredititmit,VitiAkreditimit")] Infk infk)
        {
            if (id != infk.InfkId)
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
                    if (!InfkExists(infk.InfkId))
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
            ViewData["FakultetiId"] = new SelectList(_context.Fakultetis, "FakultetiId", "FakultetiId", infk.FakultetiId);
            ViewData["InstitutiId"] = new SelectList(_context.Institutis, "InstitutiId", "InstitutiId", infk.InstitutiId);
            return View(infk);
        }

        // GET: Infks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Infks == null)
            {
                return NotFound();
            }

            var infk = await _context.Infks
                .Include(i => i.Fakulteti)
                .Include(i => i.Instituti)
                .FirstOrDefaultAsync(m => m.InfkId == id);
            if (infk == null)
            {
                return NotFound();
            }

            return View(infk);
        }

        // POST: Infks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Infks == null)
            {
                return Problem("Entity set 'DataContext.Infks'  is null.");
            }
            var infk = await _context.Infks.FindAsync(id);
            if (infk != null)
            {
                _context.Infks.Remove(infk);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfkExists(int id)
        {
          return _context.Infks.Any(e => e.InfkId == id);
        }
    }
}
