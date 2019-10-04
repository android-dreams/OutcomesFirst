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
        public async Task<IActionResult> Index(int? pageNumber, string serviceSearch, string laSearch)
        {
            int pageSize = 10;
           

            var placement0 = _context.Placement
                         .Include(s => s.PlacementLocalAuthority)
                         .Include(s => s.PlacementGender)
                         .Include(s => s.PlacementService)

                         .OrderBy(o => o.PlacementService.ServiceName);



            return View(await PaginatedList<Placement>.CreateAsync(placement0.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        // GET: Placement Details - Placement shows Placements By Service so the main table is Placements
        public async Task<IActionResult> OccupancyIndex(int? pageNumber, string serviceSearch, string laSearch, string IDSearch)
        {
            int pageSize = 10;
            int searchType = 0;

            //var laQry = _context.LocalAuthority
            //           .OrderBy(x => x.LocalAuthorityName)
            //           .Select(x => x.LocalAuthorityName.ToList());

            var laQry = _context.LocalAuthority
          .OrderBy(x => x.LocalAuthorityName)
         .Select(x => x.LocalAuthorityName).ToList();

            var serviceQry = _context.Service
                       .OrderBy(x => x.ServiceName)
                       .Select(x => x.ServiceName).ToList();

            ViewBag.laSearch = new SelectList(laQry);
            ViewBag.serviceSearch = new SelectList(serviceQry);


            if (!string.IsNullOrEmpty(serviceSearch))
            {
                if (!String.IsNullOrEmpty(laSearch))
                {
                    if (string.IsNullOrEmpty(IDSearch))
                    {
                        searchType = 1;
                    }
                    else
                    {
                        searchType = 2;
                    }
                }

                else
                {
                    if (!String.IsNullOrEmpty(IDSearch))
                    {
                        searchType = 3;
                    }
                    else
                    {
                        searchType = 4;
                    }
                }
            }

            else
            {
                if (!string.IsNullOrEmpty(laSearch))
                {
                    if (!String.IsNullOrEmpty(IDSearch))
                    {
                        searchType = 5;
                    }

                    else
                    {
                        searchType = 6;
                    }
                }


                else
                {
                    if (!String.IsNullOrEmpty(IDSearch))
                    {
                        searchType = 7;
                    }

                    else
                    {
                        searchType = 8;
                    }
                }
            }
            
                 switch (searchType)
            {
                case 1:
                    var placement1 = _context.Placement
                        .Include(s => s.PlacementLocalAuthority)
                        .Include(s => s.PlacementGender)
                        .Include(s => s.PlacementService)
                        .Where(r => r.PlacementService.ServiceName == serviceSearch)
                        .Where(r => r.PlacementLocalAuthority.LocalAuthorityName == laSearch)
                        .Where(r => r.PlacementRefId.Contains(IDSearch))
                        .OrderBy(o => o.PlacementService.ServiceName);
                    return View(await PaginatedList<Placement>.CreateAsync(placement1.AsNoTracking(), pageNumber ?? 1, pageSize));



                case 2:
                    var placement2 = _context.Placement
                        .Include(s => s.PlacementLocalAuthority)
                        .Include(s => s.PlacementGender)
                        .Include(s => s.PlacementService)
                        .Where(r => r.PlacementService.ServiceName == serviceSearch)
                        .Where(r => r.PlacementLocalAuthority.LocalAuthorityName == laSearch)
                        .OrderBy(o => o.PlacementService.ServiceName);
                    return View(await PaginatedList<Placement>.CreateAsync(placement2.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 3:
                    var placement3 = _context.Placement
                        .Include(s => s.PlacementLocalAuthority)
                        .Include(s => s.PlacementGender)
                        .Include(s => s.PlacementService)
                        .Where(r => r.PlacementLocalAuthority.LocalAuthorityName == laSearch)
                        .OrderBy(o => o.PlacementService.ServiceName);
                    return View(await PaginatedList<Placement>.CreateAsync(placement3.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 4:
                    var placement4 = _context.Placement
                        .Include(s => s.PlacementLocalAuthority)
                        .Include(s => s.PlacementGender)
                        .Include(s => s.PlacementService)
                        .Where(r => r.PlacementRefId.Contains(IDSearch))
                        .OrderBy(o => o.PlacementService.ServiceName);
                    return View(await PaginatedList<Placement>.CreateAsync(placement4.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 5:
                    var placement5 = _context.Placement
                        .Include(s => s.PlacementLocalAuthority)
                        .Include(s => s.PlacementGender)
                        .Include(s => s.PlacementService)
                        .Where(r => r.PlacementRefId.Contains(IDSearch))
                        .Where(r => r.PlacementService.ServiceName == serviceSearch)
                         .OrderBy(o => o.PlacementLocalAuthority.LocalAuthorityName);
                    return View(await PaginatedList<Placement>.CreateAsync(placement5.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 6:
                    var placement6 = _context.Placement
                        .Include(s => s.PlacementLocalAuthority)
                        .Include(s => s.PlacementGender)
                        .Include(s => s.PlacementService)
                        .Where(r => r.PlacementLocalAuthority.LocalAuthorityName == laSearch)
                        .OrderBy(o => o.PlacementService.ServiceName);
                    return View(await PaginatedList<Placement>.CreateAsync(placement6.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 7:
                    var placement7 = _context.Placement
                        .Include(s => s.PlacementLocalAuthority)
                        .Include(s => s.PlacementGender)
                        .Include(s => s.PlacementService)
                        .Where(r => r.PlacementRefId.Contains(IDSearch))
                        .OrderBy(o => o.PlacementService.ServiceName);
                    return View(await PaginatedList<Placement>.CreateAsync(placement7.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 8:
                    var placement8 = _context.Placement
                        .Include(s => s.PlacementLocalAuthority)
                        .Include(s => s.PlacementGender)
                        .Include(s => s.PlacementService)
                        .OrderBy(o => o.PlacementService.ServiceName);
                    return View(await PaginatedList<Placement>.CreateAsync(placement8.AsNoTracking(), pageNumber ?? 1, pageSize));


                default:
                    var placement0 = _context.Placement
                        .Include(s => s.PlacementLocalAuthority)
                        .Include(s => s.PlacementGender)
                        .Include(s => s.PlacementService)
                        .OrderBy(o => o.PlacementService.ServiceName);
                    return View(await PaginatedList<Placement>.CreateAsync(placement0.AsNoTracking(), pageNumber ?? 1, pageSize));
            }
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

            //ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderName");
            //ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityName");
            //ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName");
            //ViewData["PlacementLeavingReasonId"] = new SelectList(_context.LeavingReason, "LeavingReasonId", "LeavingReasonName");

            return View(placement);
        }

        // GET: Placements/Create
        public IActionResult Create()
        {


            PlacementViewModel viewModel = new PlacementViewModel();
            PopulateDropDowns(viewModel);
            //ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderName");
            //ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityName");
            //ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName");
            //ViewData["PlacementLeavingReasonId"] = new SelectList(_context.LeavingReason, "LeavingReasonId", "LeavingReasonName");
            return View(viewModel);
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

            Placement model = await _context.Placement
                .Include(p => p.PlacementGender)
                .Include(p => p.PlacementLocalAuthority)
                .Include(p => p.PlacementService)
                .Include(p => p.PlacementLeavingReason)
                .FirstOrDefaultAsync(m => m.PlacementId == id);

            if (model == null)
            {
                return NotFound();
            }

            PlacementViewModel viewModel = new PlacementViewModel();

            _mapper.Map(model, viewModel);

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }

            

           


        // POST: Placement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OccupancyEdit(int id, PlacementViewModel viewModel, Placement placement)
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
            //ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderId", placement.PlacementGenderId);
            //ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId", placement.PlacementLocalAuthorityId);
            //ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId", placement.PlacementServiceId);
            //ViewData["PlacementLeavingReasonId"] = new SelectList(_context.LeavingReason, "LeavingReasonId", "LeavingReasonId", placement.PlacementLeavingReasonId);
            // return View(placement);
            return RedirectToAction(nameof(Index));
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

            viewModel.PlacementLocalAuthorities = _context.LocalAuthority.ToList();
            viewModel.PlacementGenders = _context.Gender.ToList();
            viewModel.PlacementLeavingReasons = _context.LeavingReason.ToList();
            viewModel.PlacementServices = _context.Service.ToList();


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
