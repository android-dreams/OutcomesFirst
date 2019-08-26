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


namespace OutcomesFirst.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubmissionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Submissions
        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 10;
            var servicedata = _context.Submission
                .Include(s => s.SubmissionReferral)
                .Include(s => s.SubmissionService)
                .Include(s => s.SubmissionStatus);




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
                .Include(s => s.SubmissionServiceId)
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
                .Where(i => i.ReferralId == id).Single();

            var submission = new Submission();

            var servicesList = _context.Service
                .OrderBy(s => s.ServiceName)
                .ToList();


            //Creating the ViewModel
            SubmissionIndexData submissionIndexData = new SubmissionIndexData()
            {

                MVReferralId = referral.ReferralId,
                MVReferralName = referral.ReferralName,
                //  MVGender = referral.ReferralGender.GenderName,
                //  MVAge = 10,
                //   MVLocalAuthority = referral.ReferralLocalAuthority.LocalAuthorityName,
                //   MVDateReceived = referral.ReferralReceivedDate,

                Submission = submission,
                Services = servicesList

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
                int count = submissionIndexData.Submission.IsChecked.Count;
                // string result = string.Join(",", submissionIndexData.Submission.IsChecked);
                string result = string.Join(",", submissionIndexData.Submission.IsChecked);
                var subrefid = submissionIndexData.MVReferralId;


                for (int i = 0; i < count; i++)
                {
                    var submissions = new Submission[]
                    {
                       new Submission {SubmissionReferralId= subrefid,SubmissionServiceId = Int32.Parse(submissionIndexData.Submission.IsChecked[i]),SubmissionStatusId=8}
                     };
                    foreach (Submission s in submissions)
                    {
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
        public async Task<IActionResult> Edit(int id, Submission submission)
        {
            if (id != submission.SubmissionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //get referal
                var referral = _context.Referral
                        .Where(r => r.ReferralId == submission.SubmissionReferralId).FirstOrDefault();

                submission.SubmissionReferral = referral;

                var service = _context.Service
                        .Where(r => r.ServiceId == submission.SubmissionServiceId).FirstOrDefault();

                submission.SubmissionService = service;

                if (submission.SubmissionStatusId == 1)
                {

                    Placement model = new Placement();
                    model.PlacementRefId = referral.ReferralName;
                    model.PlacementServiceId = submission.SubmissionServiceId;
                    model.PlacementType = referral.ReferralType;
                    model.PlacementGenderId = referral.ReferralGenderId;
                    model.PlacementLocalAuthorityId = referral.ReferralLocalAuthorityId;

                    _context.Update(model);
                }


                _context.Update(submission);
                await _context.SaveChangesAsync();

                var allsubmissions = _context.Submission.Where(s => s.SubmissionReferralId == referral.ReferralId);



                int? highest = 99;
                //int subid = 6;
                   
                foreach (Submission s in allsubmissions)
                {

                    //var substat = _context.Status.Where(r => r.StatusId == s.SubmissionStatusId);

                    if (s.SubmissionStatusId < highest)
                    {

                        highest = s.SubmissionStatusId;
                        //subid = s.SubmissionStatus.StatusId;

                    }
                }

                
                referral.ReferralStatusId = (int)highest;
                _context.Update(referral);
                await _context.SaveChangesAsync();

            }



            return RedirectToAction("Index", "Submissions");
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
