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
    public class ArchiveReasonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArchiveReasonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArchiveReasons
        public async Task<IActionResult> Index()
        {

           
            return View(await _context.ArchiveReason.ToListAsync());
        }

        // GET: ArchiveReasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archiveReason = await _context.ArchiveReason
                .FirstOrDefaultAsync(m => m.ArchiveReasonId == id);
            if (archiveReason == null)
            {
                return NotFound();
            }

            return View(archiveReason);
        }

        // GET: ArchiveReasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArchiveReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArchiveReasonId,ArchiveReasonName, ArchiveReasonBy")] ArchiveReason archiveReason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archiveReason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(archiveReason);
        }

        // GET: ArchiveReasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archiveReason = await _context.ArchiveReason.FindAsync(id);
            if (archiveReason == null)
            {
                return NotFound();
            }
            return View(archiveReason);
        }

        // POST: ArchiveReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArchiveReasonId,ArchiveReasonName,ArchiveReasonBy")] ArchiveReason archiveReason)
        {
            if (id != archiveReason.ArchiveReasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchiveReasonExists(archiveReason.ArchiveReasonId))
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
            return View(archiveReason);
        }

        // GET: ArchiveReasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archiveReason = await _context.ArchiveReason
                .FirstOrDefaultAsync(m => m.ArchiveReasonId == id);
            if (archiveReason == null)
            {
                return NotFound();
            }

            return View(archiveReason);
        }

        // POST: ArchiveReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archiveReason = await _context.ArchiveReason.FindAsync(id);
            _context.ArchiveReason.Remove(archiveReason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchiveReasonExists(int id)
        {
            return _context.ArchiveReason.Any(e => e.ArchiveReasonId == id);
        }
    }
}
