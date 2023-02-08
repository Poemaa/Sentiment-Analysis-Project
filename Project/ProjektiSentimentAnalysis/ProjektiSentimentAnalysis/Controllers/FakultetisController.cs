using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektiSentimentAnalysis.Models;

namespace ProjektiSentimentAnalysis.Controllers
{
    public class FakultetisController : Controller
    {
        private readonly DataContext _context;

        public FakultetisController(DataContext context)
        {
            _context = context;
        }

        // GET: Fakultetis
        public async Task<IActionResult> Index()
        {
              return View(await _context.Fakultetis.ToListAsync());
        }

        // GET: Fakultetis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fakultetis == null)
            {
                return NotFound();
            }

            var fakulteti = await _context.Fakultetis
                .FirstOrDefaultAsync(m => m.FakultetiId == id);
            if (fakulteti == null)
            {
                return NotFound();
            }

            return View(fakulteti);
        }

        // GET: Fakultetis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fakultetis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FakultetiId,Dega,TitulliDiplomimit")] Fakulteti fakulteti)
        {
            
            
                _context.Add(fakulteti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(fakulteti);
        }

        // GET: Fakultetis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fakultetis == null)
            {
                return NotFound();
            }

            var fakulteti = await _context.Fakultetis.FindAsync(id);
            if (fakulteti == null)
            {
                return NotFound();
            }
            return View(fakulteti);
        }

        // POST: Fakultetis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FakultetiId,Dega,TitulliDiplomimit")] Fakulteti fakulteti)
        {
            if (id != fakulteti.FakultetiId)
            {
                return NotFound();
            }

            
            
                try
                {
                    _context.Update(fakulteti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FakultetiExists(fakulteti.FakultetiId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            return View(fakulteti);
        }

        // GET: Fakultetis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fakultetis == null)
            {
                return NotFound();
            }

            var fakulteti = await _context.Fakultetis
                .FirstOrDefaultAsync(m => m.FakultetiId == id);
            if (fakulteti == null)
            {
                return NotFound();
            }

            return View(fakulteti);
        }

        // POST: Fakultetis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fakultetis == null)
            {
                return Problem("Entity set 'DataContext.Fakultetis'  is null.");
            }
            var fakulteti = await _context.Fakultetis.FindAsync(id);
            if (fakulteti != null)
            {
                _context.Fakultetis.Remove(fakulteti);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FakultetiExists(int id)
        {
          return _context.Fakultetis.Any(e => e.FakultetiId == id);
        }
    }
}
