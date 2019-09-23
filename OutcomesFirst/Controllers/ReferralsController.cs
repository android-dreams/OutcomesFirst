using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutcomesFirst.Data;
using OutcomesFirst.Models;
using OutcomesFirst.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


//using OutcomesFirst.ViewModels;

namespace OutcomesFirst.Controllers
{
    public class ReferralsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReferralsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: Referrals
        public async Task<IActionResult> Index(int? pageNumber, string IDSearch, string genderSearch, string laSearch, string statusSearch, string currentFilter, string sortOrder)
        {
            
          
            int pageSize = 10;
            int searchType = 0;


            var genderQry = _context.Gender
             .OrderBy(x => x.GenderName)
            .Select(x => x.GenderName).ToList();

            var laQry = _context.LocalAuthority
             .OrderBy(x => x.LocalAuthorityName)
            .Select(x => x.LocalAuthorityName).ToList();

            var statusQry = _context.Status
             .Where(x => x.StatusId != 1)
             .Where(x => x.StatusId != 2)
            .OrderBy(x => x.StatusPriority)
            .Select(x => x.StatusName).ToList();

            var outcomesFirstContext = _context.Referral
              .Include(s => s.Submissions)
              .Include(r => r.ReferralGender)
              .Include(r => r.ReferralLocalAuthority)
              .Include(r => r.ReferralStatus)
              .Include(r => r.ReferralArchiveReason)
              .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
              .OrderBy(o => o.ReferralStatus.StatusId);

         

            //if (laSearch != null)
            //    ViewBag.laSearch = new SelectList(laSearch).ToList();
            //            else
                ViewBag.laSearch = new SelectList(laQry);




            ViewBag.genderSearch = new SelectList(genderQry);
           
            ViewBag.statusSearch = new SelectList(statusQry);


            if (!String.IsNullOrEmpty(IDSearch))                         /*  if service entered */
            {
                if (!String.IsNullOrEmpty(genderSearch))                /* then if  Name entered */
                {
                    if (!String.IsNullOrEmpty(laSearch))                /*  then if status entered*/
                    {
                        if (!String.IsNullOrEmpty(statusSearch))        /*  then if status entered*/
                        {
                            searchType = 1;                             /*filter on ID, Gender,LA and status*/
                          
                        }
                        else
                        {
                            searchType = 2;                             /*Filter on ID, Gender,LA  */
                            statusSearch = currentFilter;
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(statusSearch))        /*  then if status entered*/
                        {
                            searchType = 3;                             /*filter on ID, Gender,and status*/
                        }
                        else
                        {
                            searchType = 4;                             /*Filter on ID, Gender  */
                            statusSearch = currentFilter;
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(laSearch))                /*  then if status entered*/
                    {
                        if (!String.IsNullOrEmpty(statusSearch))        /*  then if status entered*/
                        {
                            searchType = 5;                             /*filter on  Id ,LA and status*/
                        }
                        else
                        {
                            searchType = 6;                             /*Filter on ID and LA  */
                            statusSearch = currentFilter;
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(statusSearch))        /*  then if status entered*/
                        {
                            searchType = 7;                             /*filter on  ID and status*/
                        }
                        else
                        {
                            searchType = 8;                             /*Filter on ID   */
                            statusSearch = currentFilter;
                        }
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(genderSearch))               /* then if  gender entered */
                {
                    if (!String.IsNullOrEmpty(laSearch))                    /*  then if la  entered*/
                    {
                        if (!String.IsNullOrEmpty(statusSearch))            /*  then if status entered*/
                        {
                            searchType = 9;                                  /*filter on Gender,LA and status*/
                        }
                        else
                        {
                            searchType = 10;                                /*Filter on  Gender,LA  */
                            statusSearch = currentFilter;
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(statusSearch))            /*  then if status entered*/
                        {
                            searchType = 11;                                /*filter on  Genderand status*/
                        }
                        else
                        {
                            searchType = 12;                                /*Filter on  Gender */
                            statusSearch = currentFilter;
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(laSearch))                /*  then if LA entered*/
                    {
                        if (!String.IsNullOrEmpty(statusSearch))        /*  then if status entered*/
                        {
                            searchType = 13;                            /*filter on  ,LA and status*/
                        }
                        else
                        {
                            searchType = 14;                            /*Filter on  LA  */
                           
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(statusSearch))        /*  then if status entered*/
                        {
                            searchType = 15;                            /*filter on  Gender,LA and status*/
                        }
                        else
                        {
                            searchType = 16;                            /*no filter */
                        }
                    }
                }
            }

            switch (searchType)
            {
                /*filter on ID, Gender,LA and status*/
                case 1:
                    var refdata1 = _context.Referral
                        .Include(s => s.Submissions)
                       .Include(r => r.ReferralGender)
                       .Include(r => r.ReferralLocalAuthority)
                       .Include(r => r.ReferralStatus)
                       .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                       .Where(r => r.ReferralName.Contains(IDSearch))
                       .Where(r => r.ReferralLocalAuthority.LocalAuthorityName == laSearch)
                       .Where(r => r.ReferralGender.GenderName == genderSearch)
                       .Where(r => r.ReferralStatus.StatusName == statusSearch)
                       .OrderBy(o => o.ReferralStatus.StatusId);
                  
                    return View(await PaginatedList<Referral>.CreateAsync(refdata1.AsNoTracking(), pageNumber ?? 1, pageSize));

                /*Filter on ID, Gender,LA  */
                case 2:
                    var refdata2 = _context.Referral
                     .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralName.Contains(IDSearch))
                      .Where(r => r.ReferralLocalAuthority.LocalAuthorityName == laSearch)
                      .Where(r => r.ReferralGender.GenderName == genderSearch)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata2.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 3:
                    /*filter on ID, Gender,and status*/
                    var refdata3 = _context.Referral.Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralName.Contains(IDSearch))
                      .Where(r => r.ReferralGender.GenderName == genderSearch)
                      .Where(r => r.ReferralStatus.StatusName == statusSearch)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata3.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 4:
                    /*Filter on ID, Gender  */

                    var refdata4 = _context.Referral
                      .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralName.Contains(IDSearch))
                      .Where(r => r.ReferralGender.GenderName == genderSearch)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata4.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 5:   /*filter on  Id ,LA and status*/
                    var refdata5 = _context.Referral
                       .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralName.Contains(IDSearch))
                      .Where(r => r.ReferralLocalAuthority.LocalAuthorityName == laSearch)
                      .Where(r => r.ReferralStatus.StatusName == statusSearch)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata5.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 6:
                    /*Filter on ID and LA  */
                    var refdata6 = _context.Referral
                      .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralName.Contains(IDSearch))
                      .Where(r => r.ReferralLocalAuthority.LocalAuthorityName == laSearch)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata6.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 7:
                    /*filter on  ID and status*/
                    var refdata7 = _context.Referral
                      .Include(s => s.Submissions)
                     .Include(r => r.ReferralGender)
                     .Include(r => r.ReferralLocalAuthority)
                     .Include(r => r.ReferralStatus)
                     .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                     .Where(r => r.ReferralName.Contains(IDSearch))
                     .Where(r => r.ReferralStatus.StatusName == statusSearch)
                     .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata7.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 8:
                    /*Filter on ID   */
                    var refdata8 = _context.Referral
                       .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralName.Contains(IDSearch))
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata8.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 9:
                    /*filter on Gender,LA and status*/
                    var refdata9 = _context.Referral
                       .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralLocalAuthority.LocalAuthorityName == laSearch)
                      .Where(r => r.ReferralGender.GenderName == genderSearch)
                      .Where(r => r.ReferralStatus.StatusName == statusSearch)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata9.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 10:
                    /*Filter on  Gender,LA  */
                    var refdata10 = _context.Referral
                       .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralLocalAuthority.LocalAuthorityName == laSearch)
                      .Where(r => r.ReferralGender.GenderName == genderSearch)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata10.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 11:
                    /*filter on  Genderand status*/
                    var refdata11 = _context.Referral
                       .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralGender.GenderName == genderSearch)
                      .Where(r => r.ReferralStatus.StatusName == statusSearch)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata11.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 12:
                    /*Filter on  Gender */
                    var refdata12 = _context.Referral
                       .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralGender.GenderName == genderSearch)

                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata12.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 13:
                    /*filter on  ,LA and status*/
                    var refdata13 = _context.Referral
                       .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralLocalAuthority.LocalAuthorityName == laSearch)
                      .Where(r => r.ReferralStatus.StatusName == statusSearch)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata13.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 14:
                    /*Filter on  LA  */
                    var refdata14 = _context.Referral
                       .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                     .Where(r => r.ReferralLocalAuthority.LocalAuthorityName == laSearch)
                     
                     .OrderBy(o => o.ReferralStatus.StatusId);
                     return View(await PaginatedList<Referral>.CreateAsync(refdata14.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 15:
                    /*filter on  status*/
                    var refdata15 = _context.Referral
                       .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .Where(r => r.ReferralStatus.StatusName == statusSearch)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata15.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 16:
                    /*no filter */
                    var refdata16 = _context.Referral
                       .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata16.AsNoTracking(), pageNumber ?? 1, pageSize));


                default:
                    var refdata0 = _context.Referral
                .Include(s => s.Submissions)
                      .Include(r => r.ReferralGender)
                      .Include(r => r.ReferralLocalAuthority)
                      .Include(r => r.ReferralStatus)
                      .Where(r => r.ReferralStatusId != 1 & r.ReferralStatusId != 2)
                      .OrderBy(o => o.ReferralStatus.StatusId);
                    return View(await PaginatedList<Referral>.CreateAsync(refdata0.AsNoTracking(), pageNumber ?? 1, pageSize));
            }

        }


        // GET: Referral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referral = await _context.Referral
                .Include(r => r.ReferralGender)
                .Include(r => r.ReferralLocalAuthority)
                .Include(r => r.ReferralStatus)
                .Include(r => r.ReferralArchiveReason)
                .FirstOrDefaultAsync(m => m.ReferralId == id);
            if (referral == null)
            {
                return NotFound();
            }

            return View(referral);
        }

        // GET: Referral/Create
        public IActionResult Create()
        {
            ReferralViewModel viewModel = new ReferralViewModel();
            viewModel.ReferralReceivedDate = DateTime.Now;

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }

        // POST: Referral/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReferralViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Referral model = new Referral();
                _mapper.Map(viewModel, model);

                if (viewModel.ReferralArchiveReasonId == 0)
                {
                    model.ReferralArchiveReasonId = null;
                }

                ////set initial status to 'Under Consideration By Service'
                model.ReferralStatusId = 8;
                if (model.ReferralSuitableColor == "green")
                {
                    model.ReferralSuitable = true;
                    model.ReferralComments = model.ReferralSuitableComments;

                }
                else
                {
                    model.ReferralSuitable = false;
                    model.ReferralComments = model.ReferralNotSuitableComments;

                }

                _context.Add(model);
                await _context.SaveChangesAsync();

                // referral.ReferralSuitable = true;
                if (model.ReferralSuitable.Value)
                {
                    return RedirectToAction("Create", "Submissions", new { id = model.ReferralId });
                }
                else
                {
                    //set referral status to Archive
                    model.ReferralStatusId = 2;
                    model.ReferralSuitable = false;

                    var archive = new ArchiveReferral[]
                    {
                                new ArchiveReferral{ArchiveReferralName = model.ReferralName,
                                ArchiveReferralGenderId = model.ReferralGenderId,
                                ArchiveReferralLocalAuthorityId = model. ReferralLocalAuthorityId,
                                ArchiveReferralReceivedDate =   model.ReferralReceivedDate,
                                ArchiveReferralAge = model.ReferralAge,
                                ArchiveReferralComments = model.ReferralComments,
                                ArchiveReferralStatusId = model.ReferralStatusId,
                                ArchiveReferralSuitable = model.ReferralSuitable,
                                ArchiveReferralArchiveReasonId = model.ReferralArchiveReasonId,
                                ArchiveReferralSuitableComments = model.ReferralSuitableComments,
                                ArchiveReferralNotSuitableComments = model.ReferralNotSuitableComments}
                    };


                    foreach (ArchiveReferral g in archive)
                    {
                        try
                        {
                            _context.ArchiveReferral.Add(g);
                            _context.SaveChanges();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }


                }
                return RedirectToAction("Index", "Referrals");
            }
            return RedirectToAction("Index", "Referrals");
        }


        // GET: Referral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Referral model = await _context.Referral.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            ReferralViewModel viewModel = new ReferralViewModel();

            _mapper.Map(model, viewModel);

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }


        // POST: Referral/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string submit, int id, ReferralViewModel viewModel)
        {
            string frombutton = submit;

            if (id != viewModel.ReferralId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Referral model = await _context.Referral.FindAsync(id);

                    _mapper.Map(viewModel, model);

                    _context.Update(model);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferralExists(viewModel.ReferralId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }


                if (submit == "Submit to Another Service")
                {
                    return RedirectToAction("AddNew", "Submissions", new { @id = viewModel.ReferralId });

                }



                return RedirectToAction("Index", "Referrals");

            }


            // If offer is made///
            if (viewModel.ReferralStatusId == 1)
            {
                var Placement = new Placement[]
                {

                                new Placement{PlacementRefId = viewModel.ReferralName,
                                PlacementPlacementStartDate = viewModel.ReferralPlacementStartDate,
                                PlacementGenderId = viewModel.ReferralGenderId,
                                PlacementLocalAuthorityId = viewModel.ReferralLocalAuthorityId }
                };

                foreach (Placement g in Placement)
                {
                    try
                    {
                        _context.Placement.Add(g);
                        _context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    //try
                    //{
                    //    referral.ReferralStatusId = 8;
                    //    referral.ReferralArchiveReasonId
                    //   // var delref = await _context.Referral.FindAsync(id);
                    //  //  _context.Referral.Remove(delref);
                    //   await _context.SaveChangesAsync();
                    //    return RedirectToAction(nameof(Index));
                    //}

                    //catch (Exception)
                    //{
                    //    throw;
                    //}

                }

                _context.Update(viewModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }


            //If Referal is archived///
            if (viewModel.ReferralStatusId == 2)
            {


                var archive = new ArchiveReferral[]
                {

                                new ArchiveReferral{ArchiveReferralName = viewModel.ReferralName,
                                ArchiveReferralGenderId = viewModel.ReferralGenderId,
                                ArchiveReferralLocalAuthorityId = viewModel. ReferralLocalAuthorityId,
                                ArchiveReferralReceivedDate =   viewModel.ReferralReceivedDate,
                                ArchiveReferralAge = viewModel.ReferralAge,
                                ArchiveReferralComments = viewModel.ReferralComments,
                                ArchiveReferralStatusId = viewModel.ReferralStatusId,
                                ArchiveReferralSuitable = viewModel.ReferralSuitable,
                                ArchiveReferralArchiveReasonId = viewModel.ReferralArchiveReasonId,
                                ArchiveReferralSuitableComments = viewModel.ReferralSuitableComments,
                                ArchiveReferralNotSuitableComments = viewModel.ReferralNotSuitableComments,
                                ArchiveReferralType = viewModel.ReferralType}
                };


                foreach (ArchiveReferral g in archive)
                {
                    try
                    {
                        _context.ArchiveReferral.Add(g);
                        _context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                try
                {
                    var delref = await _context.Referral.FindAsync(id);
                    _context.Referral.Remove(delref);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                catch (Exception)
                {
                    throw;
                }
            }


            return RedirectToAction(nameof(Index));

        }


        // GET: Referral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referral = await _context.Referral
                .Include(r => r.ReferralGender)
                .Include(r => r.ReferralLocalAuthority)
                .Include(r => r.ReferralStatus)
                .Include(r => r.ReferralArchiveReason)
                .FirstOrDefaultAsync(m => m.ReferralId == id);
            if (referral == null)
            {
                return NotFound();
            }

            return View(referral);
        }

        // POST: Referral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referral = await _context.Referral.FindAsync(id);
            _context.Referral.Remove(referral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [AcceptVerbs("Get", "Post")]
        private bool ReferralExists(int id)
        {
            return _context.Referral.Any(e => e.ReferralId == id);
        }
        public IActionResult VerifyReferralName(string referralName)
        {
            var res = _context.Referral.Where(r => r.ReferralName == referralName).ToList();

            if (res.Count > 0)
            {
                return Json($"Referral Name {referralName} is already in use");

            }

            return Json(true);
        }

        private void PopulateDropDowns(ReferralViewModel viewModel)
        {
            //for (int i=2000; i< 2019; i++)
            //{
            //    viewModel.DOBYear = i;
            //}

            viewModel.localAuthorities = _context.LocalAuthority.ToList();
            viewModel.genders = _context.Gender.ToList();
            viewModel.statuses = _context.Status.ToList();
            viewModel.archiveReasons = _context.ArchiveReason.ToList();
        }


        internal class DBEntities
        {
        }
    }
}

