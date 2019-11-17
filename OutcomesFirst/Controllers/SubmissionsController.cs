using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutcomesFirst.Models;
using OutcomesFirst.Data;
using OutcomesFirst.ViewModels;
using System;
using AutoMapper;
using OutcomesFirst.Enum;
namespace OutcomesFirst.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubmissionsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Submissions
        public async Task<IActionResult> Index(int? pageNumber, string searchString, string svcSearch, string statusSearch)
        {
            int searchType = 0;
            int pageSize = 10;

            var svcList = new List<string>();

            var svcQry = _context.Service
                 .OrderBy(x => x.ServiceName)
                 .Select(x => x.ServiceName).ToList();

            var statusQry = _context.Status
                 .Where(x => x.StatusId != 1)
                 .Where(x => x.StatusId != 2)
                .OrderBy(x => x.StatusPriority)
                .Select(x => x.StatusName).ToList();

            ViewBag.svcSearch = new SelectList(svcQry);
            ViewBag.statusSearch = new SelectList(statusQry);


            if (!String.IsNullOrEmpty(svcSearch))               /*  if service entered */
            {
                if (!String.IsNullOrEmpty(searchString))        /* then if  Name entered */
                {
                    if (!String.IsNullOrEmpty(statusSearch))    /*  then if status entered*/
                    {
                        searchType = 1;                         /*filter on Service and Name  and status*/
                    }
                    else
                    {
                        searchType = 2;                         /*filter on Service and Name */
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(statusSearch))
                    {
                        searchType = 3;                          /* filter on Service and status only */
                    }
                    else
                    {
                        searchType = 4;                        /* filter on Service  only */
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))     /*  then if name entered*/
                {
                    if (!String.IsNullOrEmpty(statusSearch)) /* and status entered*/
                    {
                        searchType = 5;                    /* filter on Name and status only */
                    }
                    else
                    {
                        searchType = 6;                 /* filter on Name  only */
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(statusSearch)) /* and status entered*/
                    {
                        searchType = 7;     /*status only */
                    }
                    else
                    {
                        searchType = 8; /* no filter */
                    }
                }
            }

            var exclusions = _context.Submission
                            .Where(s => (StatusEnum)s.SubmissionStatusId == StatusEnum.Placed);

            switch (searchType)
            {

 /*  search  on Service and Name and Status*/
                case 1:
                    var servicedata1 = _context.Submission
                   .Include(s => s.SubmissionReferral)
                   .Include(s => s.SubmissionService)
                   .Include(s => s.SubmissionStatus)
                    .Where(s => !exclusions.Any(i => i.SubmissionReferralId == s.SubmissionReferralId))
                   .Where(s => s.SubmissionStatusId != 1 && s.SubmissionStatusId != 2)
                   .Where(s => s.SubmissionReferral.ReferralName.Contains(searchString))
                   .Where(s => s.SubmissionService.ServiceName == svcSearch)
                   .Where(s => s.SubmissionStatus.StatusName == statusSearch)
                   .OrderBy(o => o.SubmissionStatus.StatusName);
                    return View(await PaginatedList<Submission>.CreateAsync(servicedata1.AsNoTracking(), pageNumber ?? 1, pageSize));

                /* search on Service  and Name */
                case 2:

                    var servicedata2 = _context.Submission
                  .Include(s => s.SubmissionReferral)
                  .Include(s => s.SubmissionService)
                  .Include(s => s.SubmissionStatus)
                    .Where(s => !exclusions.Any(i => i.SubmissionReferralId == s.SubmissionReferralId))

                  .Where(s => s.SubmissionStatusId != 1 && s.SubmissionStatusId != 2)
                   .Where(s => s.SubmissionReferral.ReferralName.Contains(searchString))
                  .Where(s => s.SubmissionService.ServiceName == svcSearch)
                  .OrderBy(o => o.SubmissionStatus.StatusName);
                    return View(await PaginatedList<Submission>.CreateAsync(servicedata2.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 3:
                    /* search Service & Status */

                    var servicedata3 = _context.Submission
                  .Include(s => s.SubmissionReferral)
                  .Include(s => s.SubmissionService)
                  .Include(s => s.SubmissionStatus)
                    .Where(s => !exclusions.Any(i => i.SubmissionReferralId == s.SubmissionReferralId))

                  .Where(s => s.SubmissionStatusId != 1 && s.SubmissionStatusId != 2)
                  .Where(s => s.SubmissionStatus.StatusName == statusSearch)
                  .Where(s => s.SubmissionService.ServiceName == svcSearch)
                  .OrderBy(o => o.SubmissionStatus.StatusName);
                    return View(await PaginatedList<Submission>.CreateAsync(servicedata3.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 4:
                    /* search Name  only */

                    var servicedata4 = _context.Submission
                   .Include(s => s.SubmissionReferral)
                   .Include(s => s.SubmissionService)
                   .Include(s => s.SubmissionStatus)
                    .Where(s => !exclusions.Any(i => i.SubmissionReferralId == s.SubmissionReferralId))

                   .Where(s => s.SubmissionStatusId != 1 && s.SubmissionStatusId != 2)
                    .Where(s => s.SubmissionService.ServiceName == svcSearch)
                    .OrderBy(o => o.SubmissionStatus.StatusName);
                    return View(await PaginatedList<Submission>.CreateAsync(servicedata4.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 5: /*Name and Status */

                    var servicedata5 = _context.Submission
                   .Include(s => s.SubmissionReferral)
                   .Include(s => s.SubmissionService)
                   .Include(s => s.SubmissionStatus)
                    .Where(s => !exclusions.Any(i => i.SubmissionReferralId == s.SubmissionReferralId))

                   .Where(s => s.SubmissionStatusId != 1 && s.SubmissionStatusId != 2)
                   .Where(s => s.SubmissionReferral.ReferralName.Contains(searchString))
                   .Where(s => s.SubmissionStatus.StatusName == statusSearch)
                   .OrderBy(o => o.SubmissionStatus.StatusName);
                    return View(await PaginatedList<Submission>.CreateAsync(servicedata5.AsNoTracking(), pageNumber ?? 1, pageSize));

                case 6:
                    /* Name only */

                    var servicedata6 = _context.Submission
                   .Include(s => s.SubmissionReferral)
                   .Include(s => s.SubmissionService)
                   .Include(s => s.SubmissionStatus)
                    .Where(s => !exclusions.Any(i => i.SubmissionReferralId == s.SubmissionReferralId))

                   .Where(s => s.SubmissionStatusId != 1 && s.SubmissionStatusId != 2)
                   .Where(s => s.SubmissionReferral.ReferralName.Contains(searchString))
                   .OrderBy(o => o.SubmissionStatus.StatusName);
                    return View(await PaginatedList<Submission>.CreateAsync(servicedata6.AsNoTracking(), pageNumber ?? 1, pageSize));


                case 7:
                    /* Status only */

                    var servicedata7 = _context.Submission
                   .Include(s => s.SubmissionReferral)
                   .Include(s => s.SubmissionService)
                   .Include(s => s.SubmissionStatus)
                    .Where(s => !exclusions.Any(i => i.SubmissionReferralId == s.SubmissionReferralId))

                   .Where(s => s.SubmissionStatusId != 1 && s.SubmissionStatusId != 2)
                   .Where(s => s.SubmissionStatus.StatusName == statusSearch)
                   .OrderBy(o => o.SubmissionStatus.StatusName);
                    return View(await PaginatedList<Submission>.CreateAsync(servicedata7.AsNoTracking(), pageNumber ?? 1, pageSize));

              
                default:
                    /*  No filter */
                    var servicedata0 = _context.Submission
                    .Include(s => s.SubmissionReferral)
                    .Include(s => s.SubmissionService)
                    .Include(s => s.SubmissionStatus)
                    .Where(s => !exclusions.Any(i => i.SubmissionReferralId == s.SubmissionReferralId))

                    .Where(s => s.SubmissionStatusId != 1 && s.SubmissionStatusId != 2)
                    .OrderBy(o => o.SubmissionStatus.StatusName);
                    return View(await PaginatedList<Submission>.CreateAsync(servicedata0.AsNoTracking(), pageNumber ?? 1, pageSize));

            }
        }

        // GET: Submissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = _context.Submission
                .Include(s => s.SubmissionService)
                .FirstOrDefaultAsync(m => m.SubmissionId == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);

        }

        // GET: Submissions/Create
        //public IActionResult Create(int id)
        public ViewResult Create(int id)
        {

            ViewBag.Title = "Submission Page";
            ViewBag.Header = "Add Submission Details";

            var referral = _context.Referral
                .Include(s => s.ReferralGender)
                .Include(s => s.ReferralLocalAuthority)
                .Where(i => i.ReferralId == id).Single();

            var submission = new Submission();

            var servicesList = _context.Service

                .OrderBy(s => s.ServiceName)
                .ToList();

            

            var regionsList = _context.Region.ToList();

            List<Region> RegionsList = new List<Region>();

            foreach (var item in regionsList)
            {
                var Regionexists = (from a in _context.Service
                          .Where(s => s.ServiceRegionId == item.RegionId)
                                    select new { a.ServiceRegionId }).FirstOrDefault();

                if (Regionexists != null)
                {
                    RegionsList.Add(item);
                }
            }






            //Creating the ViewModel
            SubmissionIndexData submissionIndexData = new SubmissionIndexData()
            {

                MVReferralId = referral.ReferralId,
                MVReferralName = referral.ReferralName,
                MVGender = referral.ReferralGender.GenderName,
                MVAge = referral.ReferralAge,
                MVLocalAuthority = referral.ReferralLocalAuthority.LocalAuthorityName,
                MVDateReceived = referral.ReferralReceivedDate,

                Submission = submission,
                Services = servicesList,
                regions = RegionsList

            };

            ViewData["Services.ServiceId"] = new SelectList(servicesList, "ServiceId", "ServiceName");

            return View(submissionIndexData);

        }

        // POST: Submissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Submission submission, SubmissionIndexData submissionIndexData)
        {
            if (ModelState.IsValid)
            {


                //int count = submissionIndexData.Submission.IsChecked.Count;
                if (submissionIndexData.Submission != null)
                {
                    int count = submissionIndexData.Submission.IsChecked.Count;


                    // string result = string.Join(",", submissionIndexData.Submission.IsChecked);
                    string result = string.Join(",", submissionIndexData.Submission.IsChecked);
                    var subrefid = submissionIndexData.MVReferralId;


                    for (int i = 0; i < count; i++)
                    {
                        var submissions = new Submission[]
                        {
                       new Submission {SubmissionReferralId= subrefid,SubmissionServiceId = Int32.Parse(submissionIndexData.Submission.IsChecked[i])}
                         };
                        foreach (Submission s in submissions)
                        {
                            try
                            {
                                //set initial status of submission to 'Under Consideration by Service //
                                s.SubmissionStatusId = 8;
                                _context.Submission.Add(s);
                            }
                            catch(Exception)
                            {
                                throw;
                            }
                        }


                    }

                    _context.SaveChanges();
                }
                return RedirectToAction("Index", "Referrals");

            }

            else
            {
                return RedirectToAction("Index", "Referrals");
            }

        }

        public ViewResult AddNew(int id)
        {

            var referral = _context.Referral
                .Include(s => s.ReferralGender)
                .Include(s => s.ReferralLocalAuthority)
                .Where(i => i.ReferralId == id).Single();



            //var existingSubmissions = _context.Submission
            //    .OrderBy(s => s.SubmissionService.ServiceName)
            //    .ToList();


            var servicesList = _context.Service
                .OrderBy(s => s.ServiceName)
                .ToList();

            List<ServiceViewModel> servicesVMList = new List<ServiceViewModel>();

         

            foreach (var item in servicesList)
            {
                var existingSubmission = (from a in _context.Submission
                          .Where(s => s.SubmissionServiceId == item.ServiceId)
                          .Where(s => s.SubmissionReferralId == referral.ReferralId)
                                          select new { a.SubmissionServiceId }).FirstOrDefault();

                if (existingSubmission == null)
                {
                    ServiceViewModel serviceVM = new ServiceViewModel();
                    _mapper.Map(item, serviceVM);


                    servicesVMList.Add(serviceVM);
                }
            }

            var regionsList = _context.Region.ToList();

            List<Region> RegionsList = new List<Region>();
          
            foreach (var item in regionsList)
                {
                    var Regionexists = (from a in _context.Service
                              .Where(s => s.ServiceRegionId == item.RegionId)
                               select new { a.ServiceRegionId }).FirstOrDefault();

                    if (Regionexists != null)
                    {
                          RegionsList.Add(item);
                    }
                }


           

            //Creating the ViewModel
            SubmissionsAddViewModel viewModel = new SubmissionsAddViewModel()
            {
                MVReferralId = referral.ReferralId,
                MVReferralName = referral.ReferralName,
                MVGender = referral.ReferralGender.GenderName,
                MVAge = referral.ReferralAge,
                MVLocalAuthority = referral.ReferralLocalAuthority.LocalAuthorityName,
                MVDateReceived = referral.ReferralReceivedDate,

                ServicesVM = servicesVMList,
                regions = RegionsList
            };

            ViewData["Services.ServiceId"] = new SelectList(servicesList, "ServiceId", "ServiceName");

            return View(viewModel);

        }

        // POST: Submissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AddNew(Submission submission, SubmissionIndexData submissionIndexData)
        {
            if (ModelState.IsValid)
            {

                if (submissionIndexData.Submission != null)
                {
                    int count = submissionIndexData.Submission.IsChecked.Count;
                    string result = string.Join(",", submissionIndexData.Submission.IsChecked);
                    var subrefid = submissionIndexData.MVReferralId;


                    for (int i = 0; i < count; i++)
                    {
                        var submissions = new Submission[]
                        {
                       new Submission {SubmissionReferralId= subrefid,SubmissionServiceId = Int32.Parse(submissionIndexData.Submission.IsChecked[i])}
                         };
                        foreach (Submission s in submissions)
                        {
                            try
                            {
                                //set initial status of submission to 'Under Consideration by Service //
                                s.SubmissionStatusId = 8;
                                _context.Submission.Add(s);
                            }
                            catch
                            {
                                throw;
                            }
                        }

                    }
                    _context.SaveChanges();
                }
                return RedirectToAction("Index", "Referrals");

            }

            else
            {
                return RedirectToAction("Index", "Referrals");
            }

        }



        // GET: Submissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var submissionModel = await _context.Submission
            .Include(r => r.SubmissionReferral)
            .Include(r => r.SubmissionStatus)
            .Include(r => r.SubmissionService)
             .Include(r => r.SubmissionArchiveReason)
             .FirstOrDefaultAsync(r => r.SubmissionId == id);

            if (submissionModel == null)
            {
                return NotFound();
            }

            SubmissionViewModel viewModel = new SubmissionViewModel();

            _mapper.Map(submissionModel, viewModel);

            PopulateDropDowns(viewModel);


            //ViewData["SubmissionReferralId"] = new SelectList(_context.Referral, "ReferralId", "ReferralName", submission.SubmissionReferralId);
            //ViewData["SubmissionStatusId"] = new SelectList(_context.Status, "StatusId", "StatusName", submission.SubmissionStatusId);
            //ViewData["SubmissionServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName", submission.SubmissionServiceId);
            //ViewData["SubmissionArchiveReasonId"] = new SelectList(_context.ArchiveReason, "ArchiveReasonId", "ArchiveReasonName", submission.SubmissionArchiveReasonId);

            return View(viewModel);
        }



        // POST: Submissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SubmissionViewModel viewModel)
        {
            PopulateDropDowns(viewModel);

            if (id != viewModel.SubmissionId)
            {
                return NotFound();
            }

            if (viewModel.SubmissionStatusId == 1 && viewModel.SubmissionPlacementStartDate == null)
            {
                ModelState.AddModelError(string.Empty, "You must enter an Placement Start Date when status is set to 'Placed'");
            }

            if (viewModel.SubmissionStatusId == 2 && viewModel.SubmissionArchiveReasonId == null)
            {
                ModelState.AddModelError(string.Empty, "You must enter an Archive Reason");
            }

            if (ModelState.IsValid)
            {
                //Update Submission
                Submission submissionModel = await _context.Submission.FindAsync(id);
                
                submissionModel.SubmissionStatusId = viewModel.SubmissionStatusId;
              
                _context.Update(submissionModel);
                _context.SaveChanges();

                // Referral
                var referral = _context.Referral
                     .Where(r => r.ReferralId == submissionModel.SubmissionReferralId).FirstOrDefault();

                submissionModel.SubmissionReferral = referral;
                var service = _context.Service
                     .Where(r => r.ServiceId == submissionModel.SubmissionServiceId).FirstOrDefault();
                submissionModel.SubmissionService = service;
                var subrefid = submissionModel.SubmissionReferralId;

                // Submission model = await _context.Submission.FindAsync(id);
                if (submissionModel.SubmissionStatusId == 1)
                {
                    Placement model = new Placement();
                    model.PlacementRefId = referral.ReferralName;
                    model.PlacementServiceId = submissionModel.SubmissionServiceId;
                    model.PlacementType = referral.ReferralType;
                    model.PlacementGenderId = referral.ReferralGenderId;
                    model.PlacementLocalAuthorityId = referral.ReferralLocalAuthorityId;

                    try
                    {
                        _context.Update(model);
                        _context.SaveChanges();

                    }
                    catch (Exception)
                    {
                        throw;
                    }

                    //If a submission has been set to 'Placed', update the referral to placed.
                    try
                    {
                        referral.ReferralStatusId = 1;
                        _context.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        throw;
                    }
                }

                // Update the referral with the highest status (actually the lowest)
                var allsubmissions = _context.Submission.Where(s => s.SubmissionReferralId == referral.ReferralId);

                int? highest = 8;
                //int subid = 6;

                foreach (Submission s in allsubmissions)
                {
                    //var substat = _context.Status.Where(r => r.StatusId == s.SubmissionStatusId);
                    if (s.SubmissionStatusId < highest && s.SubmissionStatusId > 2)
                    {
                        highest = s.SubmissionStatusId;
                        //subid = s.SubmissionStatus.StatusId;
                    }                                   
                }

                /* only  update referral if status is not Archived  or Placed (the Archive  decison made at head office and is made directly on the referral record
                because if all submissions are rejected by the services, head-office may submit to other services. Does this need to be confirmed with Kerry?*/
                if (highest > 2 & referral.ReferralStatusId >2)
                { 
                    referral.ReferralStatusId = (int)highest;
                    try
                    {
                        _context.Update(referral);
                        _context.SaveChanges();
                    }
                    catch(Exception)
                    { throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }


        // GET: Submissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submission
                .Include(s => s.SubmissionServiceId)
                .FirstOrDefaultAsync(m => m.SubmissionId == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // POST: Submissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submission = await _context.Submission.FindAsync(id);
            _context.Submission.Remove(submission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmissionExists(int id)
        {
            return _context.Submission.Any(e => e.SubmissionId == id);
        }

        private void PopulateDropDowns(SubmissionViewModel viewModel)
        {
            //for (int i=2000; i< 2019; i++)
            //{
            //    viewModel.DOBYear = i;
            //}

            viewModel.Services = _context.Service.ToList();
            viewModel.Statuses = _context.Status.ToList();
            viewModel.ArchiveReasons = _context.ArchiveReason.ToList();
        }
    }
}
