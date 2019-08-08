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
    public class LeaversController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaversController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Leavers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Occupancy
                .Include(o => o.OccupancyGender)
                .Include(o => o.OccupancyLocalAuthority)
                .Include(o => o.OccupancyService)
                .Where(o => o.OccupancyLeaveDate != null);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Leavers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupancy = await _context.Occupancy
                .Include(o => o.OccupancyGender)
                .Include(o => o.OccupancyLocalAuthority)
                .Include(o => o.OccupancyService)
                .FirstOrDefaultAsync(m => m.OccupancyId == id);
            if (occupancy == null)
            {
                return NotFound();
            }

            return View(occupancy);
        }

        // GET: Leavers/Create
        public IActionResult Create()
        {
            ViewData["OccupancyGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderId");
            ViewData["OccupancyLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId");
            ViewData["OccupancyServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId");
            return View();
        }

        // POST: Leavers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OccupancyId,OccupancyRefId,OccupancyFirstName,OccupancyLastName,OccupancyGenderId,OccupancyType,OccupancyServiceTransition,OccupancyServiceId,OccupancyDateStartedWithGroup,OccupancyPlacementStartDate,OccupancyDOB,OccupancyAgeAtLeaving,OccupancyLocalAuthorityId,OccupancyFramework,OccupancyWeeklyFee,OccupancyLengthOfStayWithGroup,OccupancyLengthOfStayWithPlacement,OccupancyNotes,OccupancyLeaveDate,OccupancyLeaverType,OccupancyReasonForLeavingID")] Occupancy occupancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(occupancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OccupancyGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderName", occupancy.OccupancyGenderId);
            ViewData["OccupancyLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityName", occupancy.OccupancyLocalAuthorityId);
            ViewData["OccupancyServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName", occupancy.OccupancyServiceId);
            return View(occupancy);
        }

        // GET: Leavers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupancy = await _context.Occupancy.FindAsync(id);
            if (occupancy == null)
            {
                return NotFound();
            }
            ViewData["OccupancyGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderName", occupancy.OccupancyGenderId);
            ViewData["OccupancyLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityName", occupancy.OccupancyLocalAuthorityId);
            ViewData["OccupancyServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName", occupancy.OccupancyServiceId);
            return View(occupancy);
        }

        // POST: Leavers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OccupancyId,OccupancyRefId,OccupancyFirstName,OccupancyLastName,OccupancyGenderId,OccupancyType,OccupancyServiceTransition,OccupancyServiceId,OccupancyDateStartedWithGroup,OccupancyPlacementStartDate,OccupancyDOB,OccupancyAgeAtLeaving,OccupancyLocalAuthorityId,OccupancyFramework,OccupancyWeeklyFee,OccupancyLengthOfStayWithGroup,OccupancyLengthOfStayWithPlacement,OccupancyNotes,OccupancyLeaveDate,OccupancyLeaverType,OccupancyReasonForLeavingID")] Occupancy occupancy)
        {
            if (id != occupancy.OccupancyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(occupancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OccupancyExists(occupancy.OccupancyId))
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
            ViewData["OccupancyGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderId", occupancy.OccupancyGenderId);
            ViewData["OccupancyLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId", occupancy.OccupancyLocalAuthorityId);
            ViewData["OccupancyServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", occupancy.OccupancyServiceId);
            return View(occupancy);
        }

        // GET: Leavers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupancy = await _context.Occupancy
                .Include(o => o.OccupancyGender)
                .Include(o => o.OccupancyLocalAuthority)
                .Include(o => o.OccupancyService)
                .FirstOrDefaultAsync(m => m.OccupancyId == id);
            if (occupancy == null)
            {
                return NotFound();
            }

            return View(occupancy);
        }

        // POST: Leavers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var occupancy = await _context.Occupancy.FindAsync(id);
            _context.Occupancy.Remove(occupancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OccupancyExists(int id)
        {
            return _context.Occupancy.Any(e => e.OccupancyId == id);
        }
    }
}
