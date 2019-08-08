using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutcomesFirst.Data;
using OutcomesFirst.Models;

namespace OutcomesFirst.Controllers
{
    public class LeavingReasonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeavingReasonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeavingReasons
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeavingReason.ToListAsync());
        }

        // GET: LeavingReasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavingReason = await _context.LeavingReason
                .FirstOrDefaultAsync(m => m.LeavingReasonId == id);
            if (leavingReason == null)
            {
                return NotFound();
            }

            return View(leavingReason);
        }

        // GET: LeavingReasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeavingReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeavingReasonId,LeavingReasonDesc")] LeavingReason leavingReason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leavingReason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leavingReason);
        }

        // GET: LeavingReasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavingReason = await _context.LeavingReason.FindAsync(id);
            if (leavingReason == null)
            {
                return NotFound();
            }
            return View(leavingReason);
        }

        // POST: LeavingReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeavingReasonId,LeavingReasonDesc")] LeavingReason leavingReason)
        {
            if (id != leavingReason.LeavingReasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leavingReason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeavingReasonExists(leavingReason.LeavingReasonId))
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
            return View(leavingReason);
        }

        // GET: LeavingReasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavingReason = await _context.LeavingReason
                .FirstOrDefaultAsync(m => m.LeavingReasonId == id);
            if (leavingReason == null)
            {
                return NotFound();
            }

            return View(leavingReason);
        }

        // POST: LeavingReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leavingReason = await _context.LeavingReason.FindAsync(id);
            _context.LeavingReason.Remove(leavingReason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeavingReasonExists(int id)
        {
            return _context.LeavingReason.Any(e => e.LeavingReasonId == id);
        }
    }
}
