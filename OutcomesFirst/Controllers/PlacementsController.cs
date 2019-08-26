using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutcomesFirst.Data;
using OutcomesFirst.Models;
using OutcomesFirst.ViewModels;

namespace OutcomesFirst
{
    public class PlacementsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public PlacementsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Placements
        public async Task<IActionResult> Index()
        {

            PlacementViewModel viewModel = new PlacementViewModel();

            var placements = await _context.Placement.ToArrayAsync();

            IEnumerable<PlacementViewModel> placementVM = _mapper.Map<Placement[], IEnumerable<PlacementViewModel>>(placements);

            return View(placementVM);


        }


        // GET: Occupancy Details - Occupancy shows Placements By Service so the main table is Placements
        public async Task<IActionResult> OccupancyIndex()
        {
            var applicationDbContext = _context.Placement
               .Include(p => p.PlacementGender)
                .Include(p => p.PlacementLocalAuthority)
                .Include(p => p.PlacementService)
                .Include(p => p.PlacementLeavingReason)
                .OrderBy(p => p.PlacementService.ServiceName);


            ViewData["PlacementLeavingReasonId"] = new SelectList(_context.LeavingReason, "LeavingReasonId", "LeavingReasonName");
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
                 .Include(p => p.PlacementLeavingReason)
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
            ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityName");
            ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName");
            ViewData["PlacementLeavingReasonId"] = new SelectList(_context.LeavingReason, "LeavingReasonId", "LeavingReasonName");
            return View();
        }

        // POST: Placements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlacementId,PlacementRefId,PlacementFirstName,PlacementLastName,PlacementGenderId,PlacementType,PlacementServiceTransition,PlacementServiceId,PlacementDateStartedWithGroup,PlacementPlacementStartDate,PlacementDOB,PlacementAgeAtLeaving,PlacementLocalAuthorityId,PlacementFramework,PlacementWeeklyFee,PlacementLengthOfStayWithGroup,PlacementLengthOfStayWithPlacement,PlacementNotes,PlacementLeaveDate,PlacementLeaverType,PlacementLeavingReasonId")] Placement placement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PlacementViewModel viewModel = new PlacementViewModel();
            PopulateDropDowns(viewModel);

            //ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderId", placement.PlacementGenderId);
            //ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId", placement.PlacementLocalAuthorityId);
            //ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", placement.PlacementServiceId);
            //ViewData["PlacementLeavingReasonId"] = new SelectList(_context.LeavingReason, "LeavingReasonId", "LeavingReasonId", placement.PlacementLeavingReasonId);
            return View(placement);
        }

        // GET: Placements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Placement.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            PlacementViewModel viewModel = new PlacementViewModel();

               
            _mapper.Map(model, viewModel);

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }

        // POST: Placements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlacementId,PlacementRefId,PlacementFirstName,PlacementLastName,PlacementGenderId,PlacementType,PlacementServiceTransition,PlacementServiceId,PlacementDateStartedWithGroup,PlacementPlacementStartDate,PlacementDOB,PlacementAgeAtLeaving,PlacementLocalAuthorityId,PlacementFramework,PlacementWeeklyFee,PlacementLengthOfStayWithGroup,PlacementLengthOfStayWithPlacement,PlacementNotes,PlacementLeaveDate,PlacementLeaverType,PlacementLeavingReasonId")] PlacementViewModel viewModel)
        {
            if (id != viewModel.PlacementId)
            {
                return NotFound();
            }

            
            if (ModelState.IsValid)
            {
                try
                {
                    Placement model = await _context.Placement.FindAsync(id);

                    _mapper.Map(viewModel, model);

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacementExists(viewModel.PlacementId))
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

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }





        // GET: Placements/Edit/5
        public async Task<IActionResult> OccupancyEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placement = await _context.Placement
                .Include(p => p.PlacementGender)
                .Include(p => p.PlacementLocalAuthority)
                .Include(p => p.PlacementService)
                .Include(p => p.PlacementLeavingReason)
                .FirstOrDefaultAsync(m => m.PlacementId == id);
       
            if (placement == null)
            {
                return NotFound();
            }
           
            ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderName", placement.PlacementGenderId);
            ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityName", placement.PlacementLocalAuthorityId);
            ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName", placement.PlacementServiceId);
            ViewData["PlacementLeavingReasonId"] = new SelectList(_context.LeavingReason, "LeavingReasonId", "LeavingReasonName",placement.PlacementLeavingReasonId);
            return View(placement);
        }

        // POST: Occupancy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OccupancyEdit(int id, [Bind("PlacementId,PlacementRefId,PlacementFirstName,PlacementLastName,PlacementGenderId,PlacementType,PlacementServiceTransition,PlacementServiceId,PlacementDateStartedWithGroup,PlacementPlacementStartDate,PlacementDOB,PlacementAgeAtLeaving,PlacementLocalAuthorityId,PlacementFramework,PlacementWeeklyFee,PlacementLengthOfStayWithGroup,PlacementLengthOfStayWithPlacement,PlacementNotes,PlacementLeaveDate,PlacementLeaverType,PlacemenLeavingReasonId")] Placement placement)
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
            ViewData["PlacementLeavingReasonId"] = new SelectList(_context.LeavingReason, "LeavingReasonId", "LeavingReasonId", placement.PlacementLeavingReasonId);
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

        private void PopulateDropDowns(PlacementViewModel viewModel)
        {

            viewModel.localAuthorities = _context.LocalAuthority.ToList();
            viewModel.genders = _context.Gender.ToList();
            viewModel.leavingReasons = _context.LeavingReason.ToList();

            List<int> years = new List<int>();
            List<int> months = new List<int>();

            for (int i = 1900; i <= 2020; i++)
            {
                years.Add(i);
            }

            viewModel.years = years;

        }
    }
}
