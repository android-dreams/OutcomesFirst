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
        public async Task<IActionResult> Index()
        {
            var servicedata = _context.Submission
                .Include(s => s.SubmissionReferral)
                .Include(s => s.SubmissionService);
           
            return View(await servicedata.ToListAsync());
           

        }


        // GET: Submissions/Create
        //public IActionResult Create(int id)
        public ViewResult Create(int id)
        {
            var referral = _context.Referral
                .Where(i => i.ReferralId == id).Single();

            var regions = _context.Region
                .ToList();

            var services = _context.Service
              .Include(s => s.ServiceRegion)
              .OrderBy(s => s.ServiceName)
              .ToArray();


            SubmissionViewModel viewModel = new SubmissionViewModel();

            IList<ServiceViewModel> serviceVM = _mapper.Map<Service[], List<ServiceViewModel>>(services);

            _mapper.Map(serviceVM, services);

            viewModel.SubmissionReferralId = id;

            viewModel.regions = regions;
            viewModel.services = serviceVM;

            ////Creating the ViewModel
            //SubmissionIndexData submissionIndexData = new SubmissionIndexData()
            //{

            //    MVReferralId = referral.ReferralId,
            //    MVReferralName = referral.ReferralName,
            //    //  MVGender = referral.ReferralGender.GenderName,
            //    //  MVAge = 10,
            //    //   MVLocalAuthority = referral.ReferralLocalAuthority.LocalAuthorityName,
            //    //   MVDateReceived = referral.ReferralReceivedDate,

            //    Submission = submission,
            //    Services = servicesList

            //};

            //ViewData["Services.ServiceId"] = new SelectList(servicesList, "ServiceId", "ServiceName");

            return View(viewModel);

        }

        // POST: Submissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubmissionViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                int count = viewModel.services.Count;

                for (int i = 0; i < viewModel.services.Count; i++)
                {
                    if (viewModel.services[i].IsChecked == true)
                    {
                        Submission model = new Submission();

                        _mapper.Map(viewModel, model);
                        _context.Submission.Add(model);


                    }
                    //var submissions = new Submission[]
                    //{
                    //   new Submission {SubmissionReferralId= subrefid,SubmissionServiceId = Int32.Parse(submissionIndexData.Submission.IsChecked[i])}
                    // };
                    //foreach (Submission s in submissions)
                    //{
                    //    _context.Submission.Add(s);
                    //}

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
    public async Task<IActionResult> Edit(int id, [Bind("SubmissionId,SubmissionName")] Submission submission)
    {
        if (id != submission.SubmissionId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(submission);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
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
    }
}
