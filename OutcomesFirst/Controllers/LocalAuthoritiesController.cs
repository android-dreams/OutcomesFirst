using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutcomesFirst.Models;
using OutcomesFirst.Data;

namespace OutcomesFirst.Controllers
{
    public class LocalAuthoritiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalAuthoritiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocalAuthorities
        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 5;
            var outcomesFirstContext = _context.LocalAuthority
              .Include(r => r.LocalAuthorityRegion)
              .OrderBy(o => o.LocalAuthorityName);
             
            return View(await PaginatedList<LocalAuthority>.CreateAsync(outcomesFirstContext.AsNoTracking(), pageNumber ?? 1, pageSize));

         
        }

        // GET: LocalAuthorities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localAuthority = await _context.LocalAuthority
                .FirstOrDefaultAsync(m => m.LocalAuthorityId == id);
            if (localAuthority == null)
            {
                return NotFound();
            }

            return View(localAuthority);
        }

        // GET: LocalAuthorities/Create
        public IActionResult Create()
        {
         
            ViewData["LocalAuthorityRegionId"] = new SelectList(_context.Region, "RegionId", "RegionName");
            return View();
        }

        // POST: LocalAuthorities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalAuthorityId,LocalAuthorityName,LocalAuthorityRegionId")] LocalAuthority localAuthority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localAuthority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LocalAuthorityRegionId"] = new SelectList(_context.Region, "RegionId", "RegionName");
            return View(localAuthority);
        }

        // GET: LocalAuthorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localAuthority = await _context.LocalAuthority.FindAsync(id);
            if (localAuthority == null)
            {
                return NotFound();
            }

 
            ViewData["LocalAuthorityRegionId"] = new SelectList(_context.Region, "RegionId", "RegionName", localAuthority.LocalAuthorityRegionId);
            // ViewData["LocalAuthorityRegionId"] = new SelectList(_context.Region, "RegionId", "RegionName", localAuthority.LocalAuthorityRegionId);
            return View(localAuthority);
        }

        // POST: LocalAuthorities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalAuthorityId,LocalAuthorityName,LocalAuthorityRegionId")] LocalAuthority localAuthority)
        {
            if (id != localAuthority.LocalAuthorityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localAuthority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalAuthorityExists(localAuthority.LocalAuthorityId))
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

            ViewData["LocalAuthorityRegionId"] = new SelectList(_context.Region, "RegionId", "RegionId", localAuthority.LocalAuthorityRegionId);
            return View(localAuthority);
        }

        // GET: LocalAuthorities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localAuthority = await _context.LocalAuthority
                .FirstOrDefaultAsync(m => m.LocalAuthorityId == id);
            if (localAuthority == null)
            {
                return NotFound();
            }

            return View(localAuthority);
        }

        // POST: LocalAuthorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localAuthority = await _context.LocalAuthority.FindAsync(id);
            _context.LocalAuthority.Remove(localAuthority);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalAuthorityExists(int id)
        {
            return _context.LocalAuthority.Any(e => e.LocalAuthorityId == id);
        }
    }
}
