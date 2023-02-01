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
    public class UserAccsController : Controller
    {
        private readonly draftP1Context _context;

        public UserAccsController(draftP1Context context)
        {
            _context = context;
        }

        // GET: UserAccs
        public async Task<IActionResult> Index()
        {
            var draftP1Context = _context.UserAccs.Include(u => u.IdUserNavigation);
            return View(await draftP1Context.ToListAsync());
        }

        // GET: UserAccs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserAccs == null)
            {
                return NotFound();
            }

            var userAcc = await _context.UserAccs
                .Include(u => u.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (userAcc == null)
            {
                return NotFound();
            }

            return View(userAcc);
        }

        // GET: UserAccs/Create
        public IActionResult Create()
        {
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser");
            return View();
        }

        // POST: UserAccs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,Email,Password,Roli")] UserAcc userAcc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAcc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", userAcc.IdUser);
            return View(userAcc);
        }

        // GET: UserAccs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserAccs == null)
            {
                return NotFound();
            }

            var userAcc = await _context.UserAccs.FindAsync(id);
            if (userAcc == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", userAcc.IdUser);
            return View(userAcc);
        }

        // POST: UserAccs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,Email,Password,Roli")] UserAcc userAcc)
        {
            if (id != userAcc.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAcc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccExists(userAcc.IdUser))
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
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", userAcc.IdUser);
            return View(userAcc);
        }

        // GET: UserAccs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserAccs == null)
            {
                return NotFound();
            }

            var userAcc = await _context.UserAccs
                .Include(u => u.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (userAcc == null)
            {
                return NotFound();
            }

            return View(userAcc);
        }

        // POST: UserAccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserAccs == null)
            {
                return Problem("Entity set 'draftP1Context.UserAccs'  is null.");
            }
            var userAcc = await _context.UserAccs.FindAsync(id);
            if (userAcc != null)
            {
                _context.UserAccs.Remove(userAcc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccExists(int id)
        {
          return _context.UserAccs.Any(e => e.IdUser == id);
        }
    }
}
