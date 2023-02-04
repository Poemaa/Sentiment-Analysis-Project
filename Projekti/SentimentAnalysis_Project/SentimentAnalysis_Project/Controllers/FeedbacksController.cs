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
    public class FeedbacksController : Controller
    {
        private readonly draftP1Context _context;

        public FeedbacksController(draftP1Context context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            var draftP1Context = _context.Feedbacks.Include(f => f.DegaFNavigation).Include(f => f.InstitutiFNavigation).Include(f => f.User);
            return View(await draftP1Context.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .Include(f => f.DegaFNavigation)
                .Include(f => f.InstitutiFNavigation)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Idfeedback == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Feedbacks/Create
        public IActionResult Create()
        {
            ViewData["DegaF"] = new SelectList(_context.Fakultetis, "Dega", "Dega");
            ViewData["InstitutiF"] = new SelectList(_context.Institutis, "Emri", "Emri");
            ViewData["UserId"] = new SelectList(_context.Users, "IdUser", "Emri");
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idfeedback,Permbajtja,Data,InstitutiF,DegaF,UserId")] Feedback feedback)
        {

                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["DegaF"] = new SelectList(_context.Fakultetis, "Dega", "Dega", feedback.DegaF);
            ViewData["InstitutiF"] = new SelectList(_context.Institutis, "Emri", "Emri", feedback.InstitutiF);
            ViewData["UserId"] = new SelectList(_context.Users, "IdUser", "IdUser", feedback.UserId);
            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewData["DegaF"] = new SelectList(_context.Fakultetis, "Dega", "Dega", feedback.DegaF);
            ViewData["InstitutiF"] = new SelectList(_context.Institutis, "Emri", "Emri", feedback.InstitutiF);
            ViewData["UserId"] = new SelectList(_context.Users, "IdUser", "IdUser", feedback.UserId);
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idfeedback,Permbajtja,Data,InstitutiF,DegaF,UserId")] Feedback feedback)
        {
            if (id != feedback.Idfeedback)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.Idfeedback))
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
            ViewData["DegaF"] = new SelectList(_context.Fakultetis, "Dega", "Dega", feedback.DegaF);
            ViewData["InstitutiF"] = new SelectList(_context.Institutis, "Emri", "Emri", feedback.InstitutiF);
            ViewData["UserId"] = new SelectList(_context.Users, "IdUser", "IdUser", feedback.UserId);
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Feedbacks == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .Include(f => f.DegaFNavigation)
                .Include(f => f.InstitutiFNavigation)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Idfeedback == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Feedbacks == null)
            {
                return Problem("Entity set 'draftP1Context.Feedbacks'  is null.");
            }
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
          return _context.Feedbacks.Any(e => e.Idfeedback == id);
        }
    }
}
