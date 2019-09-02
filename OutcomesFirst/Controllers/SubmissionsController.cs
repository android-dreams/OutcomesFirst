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
        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 10;

            //only show submissions that are not placed and not Archive
            var servicedata = _context.Submission
                .Include(s => s.SubmissionReferral)
                .Include(s => s.SubmissionService)
                .Include(s => s.SubmissionStatus)
                .Where(s => s.SubmissionStatusId != 1 && s.SubmissionStatusId != 2);

            return View(await PaginatedList<Submission>.CreateAsync(servicedata, pageNumber ?? 1, pageSize));

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

            var regions = _context.Region.ToList();

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
                regions = regions

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
                try
                {

                    //int count = submissionIndexData.Submission.IsChecked.Count;
                    if (submissionIndexData.Submission.IsChecked.Count > 0)
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
                                //set initial status of submission to 'Under Consideration by Service //
                                s.SubmissionStatusId = 8;
                                _context.Submission.Add(s);
                            }

                        }
                        _context.SaveChanges();

                        return RedirectToAction("Index", "Referrals");
                    }

                    else
                    {
                        return RedirectToAction("Index", "Referrals");
                    }
                }
                catch
                {

                }
            }

            else
            {
                return RedirectToAction("Index", "Referrals");
            }
            return RedirectToAction("Index", "Referrals");
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
                                           select new { a.SubmissionServiceId }).FirstOrDefault();
               
                if (existingSubmission == null)
                {
                    ServiceViewModel serviceVM = new ServiceViewModel();
                    _mapper.Map(item, serviceVM);
                    servicesVMList.Add(serviceVM);
                }           
            }

            var regions = _context.Region.OrderBy(s => s.RegionName).ToList();

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
                regions = regions
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
                        //set initial status of submission to 'Under Consideration by Service //
                        s.SubmissionStatusId = 8;
                        _context.Submission.Add(s);
                    }

                }
                _context.SaveChanges();

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


            var submission = await _context.Submission
            .Include(r => r.SubmissionReferral)
            .Include(r => r.SubmissionStatus)
            .Include(r => r.SubmissionService)
             .FirstOrDefaultAsync(r => r.SubmissionId == id);

            if (submission == null)
            {
                return NotFound();
            }


            ViewData["SubmissionReferralId"] = new SelectList(_context.Referral, "ReferralId", "ReferralName", submission.SubmissionReferralId);
            ViewData["SubmissionStatusId"] = new SelectList(_context.Status, "StatusId", "StatusName", submission.SubmissionStatusId);
            ViewData["SubmissionServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceName", submission.SubmissionServiceId);

            return View(submission);
        }



        // POST: Submissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("SubmissionId,SubmissionName,SubmissionServiceId, SubmissionStatusId,SubmissionPlacementStartDate,SubmissionReferralId")] Submission submission)
        {
            if (id != submission.SubmissionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // get referral
                var referral = _context.Referral
                     .Where(r => r.ReferralId == submission.SubmissionReferralId).FirstOrDefault();

                submission.SubmissionReferral = referral;

                var service = _context.Service
                     .Where(r => r.ServiceId == submission.SubmissionServiceId).FirstOrDefault();

                submission.SubmissionService = service;

                var subrefid = submission.SubmissionReferralId;

                // Submission model = await _context.Submission.FindAsync(id);

                if (submission.SubmissionStatusId == 1)
                {

                    Placement model = new Placement();
                    model.PlacementRefId = referral.ReferralName;
                    model.PlacementServiceId = submission.SubmissionServiceId;
                    model.PlacementType = referral.ReferralType;
                    model.PlacementGenderId = referral.ReferralGenderId;
                    model.PlacementLocalAuthorityId = referral.ReferralLocalAuthorityId;

                    _context.Update(model);

                    //archive all submissions for refid which has been placed.
                    var SubmisssionsToArchive = _context.Submission
                        .Where(s => s.SubmissionReferralId == subrefid && s.SubmissionStatusId != 1);

                    // no of submissions to archive
                    foreach (Submission s in SubmisssionsToArchive)
                    {
                        s.SubmissionStatusId = 2;
                        try
                        {
                            _context.Submission.Update(s);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        
                    }
                    _context.SaveChanges();
                }
                else
                {
                    try
                    {
                        _context.Update(submission);
                        _context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

                return RedirectToAction(nameof(Index));
            }
            return View(submission);
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
    }
}
