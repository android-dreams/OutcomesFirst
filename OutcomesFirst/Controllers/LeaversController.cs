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
            var applicationDbContext = _context.Placement
                .Include(o => o.PlacementGender)
                .Include(o => o.PlacementLocalAuthority)
                .Include(o => o.PlacementService)
                .Where(o => o.PlacementLeaveDate != null);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Leavers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Placement = await _context.Placement
                .Include(o => o.PlacementGender)
                .Include(o => o.PlacementLocalAuthority)
                .Include(o => o.PlacementService)
                .FirstOrDefaultAsync(m => m.PlacementId == id);
            if (Placement == null)
            {
                return NotFound();
            }

            return View(Placement);
        }

        // GET: Leavers/Create
        public IActionResult Create()
        {
            ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderId");
            ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId");
            ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId");
            return View();
        }

        // POST: Leavers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlacementId,PlacementRefId,PlacementFirstName,PlacementLastName,PlacementGenderId,PlacementType,PlacementServiceTransition,PlacementServiceId,PlacementDateStartedWithGroup,PlacementPlacementStartDate,PlacementDOB,PlacementAgeAtLeaving,PlacementLocalAuthorityId,PlacementFramework,PlacementWeeklyFee,PlacementLengthOfStayWithGroup,PlacementLengthOfStayWithPlacement,PlacementNotes,PlacementLeaveDate,PlacementLeaverType,PlacementReasonForLeavingID")] Placement Placement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Placement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderName", Placement.PlacementGenderId);
            ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityName", Placement.PlacementLocalAuthorityId);
            ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName", Placement.PlacementServiceId);
            return View(Placement);
        }

        // GET: Leavers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Placement = await _context.Placement.FindAsync(id);
            if (Placement == null)
            {
                return NotFound();
            }
            ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderName", Placement.PlacementGenderId);
            ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityName", Placement.PlacementLocalAuthorityId);
            ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName", Placement.PlacementServiceId);
            return View(Placement);
        }

        // POST: Leavers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlacementId,PlacementRefId,PlacementFirstName,PlacementLastName,PlacementGenderId,PlacementType,PlacementServiceTransition,PlacementServiceId,PlacementDateStartedWithGroup,PlacementPlacementStartDate,PlacementDOB,PlacementAgeAtLeaving,PlacementLocalAuthorityId,PlacementFramework,PlacementWeeklyFee,PlacementLengthOfStayWithGroup,PlacementLengthOfStayWithPlacement,PlacementNotes,PlacementLeaveDate,PlacementLeaverType,PlacementReasonForLeavingID")] Placement Placement)
        {
            if (id != Placement.PlacementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Placement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacementExists(Placement.PlacementId))
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
            ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderId", Placement.PlacementGenderId);
            ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId", Placement.PlacementLocalAuthorityId);
            ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", Placement.PlacementServiceId);
            return View(Placement);
        }

        // GET: Leavers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Placement = await _context.Placement
                .Include(o => o.PlacementGender)
                .Include(o => o.PlacementLocalAuthority)
                .Include(o => o.PlacementService)
                .FirstOrDefaultAsync(m => m.PlacementId == id);
            if (Placement == null)
            {
                return NotFound();
            }

            return View(Placement);
        }

        // POST: Leavers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Placement = await _context.Placement.FindAsync(id);
            _context.Placement.Remove(Placement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacementExists(int id)
        {
            return _context.Placement.Any(e => e.PlacementId == id);
        }
    }
}
