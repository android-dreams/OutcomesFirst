using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutcomesFirst.Data;
using OutcomesFirst.Models;
using OutcomesFirst.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using OutcomesFirst.Repository;

//using OutcomesFirst.ViewModels;

namespace OutcomesFirst.Controllers
{
    public class ReferralsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private IReferralRepository ReferralRepository { get; set; }

        public ReferralsController(ApplicationDbContext context, IMapper mapper, IReferralRepository referralRepository)
        {
            _context = context;
            _mapper = mapper;
            ReferralRepository = referralRepository;
        }


        // GET: Referrals
        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 10;
            var outcomesFirstContext = _context.Referral
              .Include(r => r.ReferralGender)
              .Include(r => r.ReferralLocalAuthority)
              .Include(r => r.ReferralStatus)
              .Include(r => r.ReferralArchiveReason)
              .Where(r => r.ReferralStatusId != 7 & r.ReferralStatusId != 8)
              .OrderBy(o => o.ReferralStatus.Priority);

            return View(await PaginatedList<Referral>.CreateAsync(outcomesFirstContext.AsNoTracking(), pageNumber ?? 1, pageSize));
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
            //set initial status to 'Under Consideration By Service'
            viewModel.ReferralStatusId = 6;

            //newref.ReferralSuitableColor = "red";
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
                
                _context.Add(model);
                await _context.SaveChangesAsync();

                // referral.ReferralSuitable = true;
                if (model.ReferralSuitableColor == "green")
                {
                    model.ReferralArchiveReasonId = null;
                    model.ReferralSuitable = true;

                    return RedirectToAction("Create", "Submissions", new { id = model.ReferralId });
                }
                else
                {
                    //set referral status to Archive
                    model.ReferralStatusId = 8;
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

        public async Task<IActionResult> SubmissionsByReferralId(int? id)
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
        public async Task<IActionResult> Edit(int id,  ReferralViewModel viewModel)
        {
            if (id != viewModel.ReferralId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (viewModel.ReferralSuitableColor == "green")
                    {
                        viewModel.ReferralSuitable = true;
                    }
                    else
                    {
                        viewModel.ReferralSuitable = false;
                    }
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

                if (viewModel.ReferralSuitable == true)
                {
                    // referral.ReferralSuitable = true;
                    viewModel.ReferralStatusId = 5;
                    return RedirectToAction("Index", "Referrals");

                }
                else
                {
                    return RedirectToAction("Index", "Referrals");


                }

            }


            // If offer is made///
            if (viewModel.ReferralStatusId == 7)
            {
                var occupancy = new Occupancy[]
                {

                                new Occupancy{OccupancyRefId = viewModel.ReferralName,
                                OccupancyPlacementStartDate = viewModel.ReferralPlacementStartDate,
                                OccupancyDOB = viewModel.ReferralDOB,
                                OccupancyGenderId = viewModel.ReferralGenderId,
                                OccupancyLocalAuthorityId = viewModel.ReferralLocalAuthorityId }
                };

                foreach (Occupancy g in occupancy)
                {
                    try
                    {
                        _context.Occupancy.Add(g);
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
            if (viewModel.ReferralStatusId == 8)
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

            //return View(referral);
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
    }

    internal class DBEntities
    {
    }
}
