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
    public class RegionalManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegionalManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegionalManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegionalManager.ToListAsync());
        }

        // GET: RegionalManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionalManager = await _context.RegionalManager
                .FirstOrDefaultAsync(m => m.RegionalManagerId == id);
            if (regionalManager == null)
            {
                return NotFound();
            }

            return View(regionalManager);
        }

        // GET: RegionalManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegionalManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionalManagerId,RegionalManagerName")] RegionalManager regionalManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regionalManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regionalManager);
        }

        // GET: RegionalManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionalManager = await _context.RegionalManager.FindAsync(id);
            if (regionalManager == null)
            {
                return NotFound();
            }
            return View(regionalManager);
        }

        // POST: RegionalManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegionalManagerId,RegionalManagerName")] RegionalManager regionalManager)
        {
            if (id != regionalManager.RegionalManagerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regionalManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionalManagerExists(regionalManager.RegionalManagerId))
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
            return View(regionalManager);
        }

        // GET: RegionalManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionalManager = await _context.RegionalManager
                .FirstOrDefaultAsync(m => m.RegionalManagerId == id);
            if (regionalManager == null)
            {
                return NotFound();
            }

            return View(regionalManager);
        }

        // POST: RegionalManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regionalManager = await _context.RegionalManager.FindAsync(id);
            _context.RegionalManager.Remove(regionalManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionalManagerExists(int id)
        {
            return _context.RegionalManager.Any(e => e.RegionalManagerId == id);
        }
    }
}
