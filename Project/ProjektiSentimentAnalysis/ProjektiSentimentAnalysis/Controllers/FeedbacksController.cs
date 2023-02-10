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
    public class FeedbacksController : Controller
    {
        private readonly DataContext _context;

        public FeedbacksController(DataContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Feedbakcs.Include(f => f.Fakulteti).Include(f => f.Instituti).Include(f=>f.ApplicationUser);
            return View(await dataContext.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Feedbakcs == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbakcs
                .Include(f => f.Fakulteti)
                .Include(f => f.Instituti)
                .Include(f => f.ApplicationUser)
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Feedbacks/Create
        public IActionResult Create()
        {
            ViewData["FakultetiId"] = new SelectList(_context.Set<Fakulteti>(), "FakultetiId", "FakultetiId");
            ViewData["InstitutiId"] = new SelectList(_context.Set<Instituti>(), "InstitutiId", "InstitutiId");
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "UserId", "Emri");
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackId,Permbajtja,Data,InstitutiId,FakultetiId,UserId")] Feedback feedback)
        {
            
            
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["FakultetiId"] = new SelectList(_context.Set<Fakulteti>(), "FakultetiId", "FakultetiId", feedback.FakultetiId);
            ViewData["InstitutiId"] = new SelectList(_context.Set<Instituti>(), "InstitutiId", "InstitutiId", feedback.InstitutiId);
            ViewData["ApplicationUser"] = new SelectList(_context.Set<ApplicationUser>(), "UserId", "UserID", feedback.UserId);
            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Feedbakcs == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbakcs.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewData["FakultetiId"] = new SelectList(_context.Set<Fakulteti>(), "FakultetiId", "FakultetiId", feedback.FakultetiId);
            ViewData["InstitutiId"] = new SelectList(_context.Set<Instituti>(), "InstitutiId", "InstitutiId", feedback.InstitutiId);
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "UserId", "UserId", feedback.UserId);
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackId,Permbajtja,Data,InstitutiId,FakultetiId,UserId")] Feedback feedback)
        {
            if (id != feedback.FeedbackId)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(feedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.FeedbackId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["FakultetiId"] = new SelectList(_context.Fakultetis, "FakultetiId", "FakultetiId", feedback.FakultetiId);
            ViewData["InstitutiId"] = new SelectList(_context.Institutis, "InstitutiId", "InstitutiId", feedback.InstitutiId);
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "UserId", "UserId", feedback.UserId);
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Feedbakcs == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbakcs
                .Include(f => f.Fakulteti)
                .Include(f => f.Instituti)
                .Include(f => f.ApplicationUser)
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
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
            if (_context.Feedbakcs == null)
            {
                return Problem("Entity set 'DataContext.Feedbakcs'  is null.");
            }
            var feedback = await _context.Feedbakcs.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedbakcs.Remove(feedback);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
          return _context.Feedbakcs.Any(e => e.FeedbackId == id);
        }
    }
}
