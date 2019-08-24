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
using Xceed.Wpf.Toolkit;
using System.Data;
using System.Configuration.Assemblies;

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
        public async Task<IActionResult> Index()
        {
            var servicedata = _context.Submission
                .Include(s => s.SubmissionReferral)
                .Include(s => s.SubmissionService);

            return View(await servicedata.ToListAsync());
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
        public ViewResult Create(string SRegion, int id, string searchString)
        {

            ViewBag.Title = "Submission Page";
            ViewBag.Header = "Add Submission Details";

            var servicesList = _context.Service
             .Include(s => s.ServiceRegion)
             .OrderBy(s => s.ServiceRegion.RegionName).ThenBy(s => s.ServiceName).ToList();

            //var servicesForSearch = _context.Service
            // .Include(s => s.ServiceRegion);

            //var services = from m in _context.Service
            //               select m;

           
            var referral = _context.Referral
                .Where(i => i.ReferralId == id).Single();

            var submission = new Submission();

            var RegionLst = new List<string>();

            
           var regionQry = from r in _context.Region
                         select r.RegionName;

            RegionLst.AddRange(regionQry.Distinct());
                     



            ViewBag.SRegion = new SelectList(RegionLst);


            //System.Data.DataTable data = GetDataFromQuery("SELECT distinct ServiceRegionId from Service");
          
            if(!String.IsNullOrEmpty(SRegion))
            {
                servicesList = servicesList.Where(s => s.ServiceRegion.RegionName.Contains(SRegion)).ToList();
            }


           

            //Creating the ViewModel
            SubmissionServicesViewModel SubmissionServicesViewModel = new SubmissionServicesViewModel()
            {

                MVReferralId = referral.ReferralId,
                MVReferralName = referral.ReferralName,
                //  MVGender = referral.ReferralGender.GenderName,
                //  MVAge = 10,
                //   MVLocalAuthority = referral.ReferralLocalAuthority.LocalAuthorityName,
                //   MVDateReceived = referral.ReferralReceivedDate,

                Submission = submission,
                SubmissionServices = servicesList

            };

           // ViewData["Services.ServiceId"] = new SelectList(servicesList, "ServiceId", "ServiceName");

            return View(SubmissionServicesViewModel);

        }

        // POST: Submissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult PostCreate( SubmissionServicesViewModel SubmissionServicesViewModel)
        {
            if (ModelState.IsValid)
            {
              
                //int count = SubmissionServicesViewModel.Submission.IsChecked.Count;
                if (SubmissionServicesViewModel.Submission != null)
                {
                     var count = SubmissionServicesViewModel.Submission.IsChecked.Count;
                    // string result = string.Join(",", SubmissionServicesViewModel.Submission.IsChecked);
                    string result = string.Join(",", SubmissionServicesViewModel.Submission.IsChecked);


                    var subrefid = SubmissionServicesViewModel.MVReferralId;


                    for (int i = 0; i < count; i++)
                    {
                        var submissions = new Submission[]
                        {
                       new Submission {SubmissionReferralId= subrefid,SubmissionServiceId = Int32.Parse(SubmissionServicesViewModel.Submission.IsChecked[i])}
                         };
                        foreach (Submission s in submissions)
                        {
                            _context.Submission.Add(s);
                        }

                    }
                    _context.SaveChanges();
                }
                else
                {
                    TempData["Message"] = "No Services Entered";
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

            //get referal
            var referral = _context.Referral
                   .Where(r => r.ReferralId == submission.SubmissionReferralId).FirstOrDefault();

            submission.SubmissionReferral = referral;

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(submission);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (!SubmissionExists(submission.SubmissionId))
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

        //DataTable GetDataFromQuery(string query)
        //{

           
        //    System.Data.SqlClient.SqlDataAdapter adap =
        //        new System.Data.SqlClient.SqlDataAdapter(query, "DefaultConnection");
        //    DataTable data = new DataTable();
        //    adap.Fill(data);
        //    return data;

        //}
    }
}

