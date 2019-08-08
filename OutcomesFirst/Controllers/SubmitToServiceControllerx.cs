using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutcomesFirst.Models;
using OutcomesFirst.Data;

namespace OutcomesFirst.Controllers
{
    public class SubmitToServiceController : Controller
    {
       
        private readonly ApplicationDbContext _context;
       
        public SubmitToServiceController(ApplicationDbContext context)
        {
            _context = context;

        }



        // GET: SubmitToService
        public async Task<IActionResult> Index()
        {
            var stsContext = _context.Referral
                 .Include(r => r.ReferralGender)
              .Include(r => r.ReferralLocalAuthority)
              .Include(r => r.ReferralStatus)
              .Include(r => r.ReferralArchiveReason);
            return View(await stsContext.ToListAsync());

        }

        // GET: SubmitToService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sts = await _context.Referral
                .Include(r => r.ReferralGender)
                .Include(r => r.ReferralLocalAuthority)
                .Include(r => r.ReferralStatus)
                .Include(r => r.ReferralArchiveReason)
                .FirstOrDefaultAsync(m => m.ReferralId == id);


            if (sts == null)
            {
                return NotFound();
            }

            return View(sts);
        }

        

        // GET: Referral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Referral sts = await _context.Referral.FindAsync(id);

            if (sts == null)
            {
                return NotFound();
            }

            ViewData["ReferralGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderName", sts.ReferralGenderId);
            ViewData["ReferralLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityName", sts.ReferralLocalAuthorityId);
            ViewData["ReferralStatusId"] = new SelectList(_context.Status, "StatusId", "StatusName", sts.ReferralStatusId);
            ViewData["ReferralArchiveReasonId"] = new SelectList(_context.ArchiveReason, "ArchiveReasonId", "ArchiveReasonName", sts.ReferralArchiveReasonId);
            return View(sts);
        }



       
    }
}











       
    