using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutcomesFirst.Data;
using OutcomesFirst.Models;

namespace OutcomesFirst
{
    public class PlacementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlacementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Placements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Placement
                 .Include(p => p.PlacementService)
                 .Include(p => p.PlacementGender)
                 .Include(p => p.PlacementLocalAuthority);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Occupancy Details - Occupancy shows Placements By Service so the main table is Placements
        public async Task<IActionResult> OccupancyIndex()
        {
            var applicationDbContext = _context.Placement
               .Include(p => p.PlacementGender)
                .Include(p => p.PlacementLocalAuthority)
                .Include(p => p.PlacementService)
                .OrderBy(p => p.PlacementService.ServiceName);


            //ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderName");
            //ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityName");
            //ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName");
            return View(await applicationDbContext.ToListAsync());
        }



        // GET: Placements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var placement = await _context.Placement
                .Include(p => p.PlacementGender)
                .Include(p => p.PlacementLocalAuthority)
                .Include(p => p.PlacementService)
                .FirstOrDefaultAsync(m => m.PlacementId == id);
            if (placement == null)
            {
                return NotFound();
            }

            return View(placement);
        }

        // GET: Placements/Create
        public IActionResult Create()
        {
            ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderName");
            ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId");
            ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId");
            return View();
        }

        // POST: Placements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlacementId,PlacementRefId,PlacementFirstName,PlacementLastName,PlacementGenderId,PlacementType,PlacementServiceTransition,PlacementServiceId,PlacementDateStartedWithGroup,PlacementPlacementStartDate,PlacementDOB,PlacementAgeAtLeaving,PlacementLocalAuthorityId,PlacementFramework,PlacementWeeklyFee,PlacementLengthOfStayWithGroup,PlacementLengthOfStayWithPlacement,PlacementNotes,PlacementLeaveDate,PlacementLeaverType,PlacementReasonForLeavingID")] Placement placement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderId", placement.PlacementGenderId);
            ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId", placement.PlacementLocalAuthorityId);
            ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", placement.PlacementServiceId);
            return View(placement);
        }

        // GET: Placements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placement = await _context.Placement.FindAsync(id);
            if (placement == null)
            {
                return NotFound();
            }
            ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderId", placement.PlacementGenderId);
            ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId", placement.PlacementLocalAuthorityId);
            ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", placement.PlacementServiceId);
            return View(placement);
        }

        // POST: Placements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlacementId,PlacementRefId,PlacementFirstName,PlacementLastName,PlacementGenderId,PlacementType,PlacementServiceTransition,PlacementServiceId,PlacementDateStartedWithGroup,PlacementPlacementStartDate,PlacementDOB,PlacementAgeAtLeaving,PlacementLocalAuthorityId,PlacementFramework,PlacementWeeklyFee,PlacementLengthOfStayWithGroup,PlacementLengthOfStayWithPlacement,PlacementNotes,PlacementLeaveDate,PlacementLeaverType,PlacementReasonForLeavingID")] Placement placement)
        {
            if (id != placement.PlacementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacementExists(placement.PlacementId))
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
            ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderId", placement.PlacementGenderId);
            ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId", placement.PlacementLocalAuthorityId);
            ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", placement.PlacementServiceId);
            return View(placement);
        }

        // GET: Placements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placement = await _context.Placement
                .Include(p => p.PlacementGender)
                .Include(p => p.PlacementLocalAuthority)
                .Include(p => p.PlacementService)
                .FirstOrDefaultAsync(m => m.PlacementId == id);
            if (placement == null)
            {
                return NotFound();
            }

            return View(placement);
        }

        // POST: Placements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placement = await _context.Placement.FindAsync(id);
            _context.Placement.Remove(placement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacementExists(int id)
        {
            return _context.Placement.Any(e => e.PlacementId == id);
        }
    }
}
