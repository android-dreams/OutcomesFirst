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

namespace OutcomesFirst.Controllers
{
    public class ArchiveReferralsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ArchiveReferralsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: ArchiveReferrals
        public async Task<IActionResult> Index()
        {
            var archive = _context.ArchiveReferral
                .Include(r => r.ArchiveReferralGender)
                .Include(r => r.ArchiveReferralLocalAuthority)
                .Include(r => r.ArchiveReferralArchiveReason);
            if (archive.Any())
            {
                return View(await archive.ToListAsync());

            }
            else
            {
                return View("No Records");
            }
        }

        // GET: ArchiveReferrals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.ArchiveReferral
                .FirstOrDefaultAsync(m => m.ArchiveReferralId == id);
            if (model == null)
            {
                return NotFound();
            }

            ArchiveReferralViewModel viewModel = new ArchiveReferralViewModel();
            _mapper.Map(model, viewModel);

            return View(model);
        }

        // GET: ArchiveReferrals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArchiveReferrals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArchiveReferralId,ArchiveReferralName,ArchiveReferralGenderId,ArchiveReferralLocalAuthorityId,ArchiveReferralReceivedDate,ArchiveReferralAge,ArchiveReferralComments,ArchiveReferralStatusId,ArchiveReferralSuitable,ArchiveReferralArchiveReasonId,ArchiveReferralSuitableComments,ArchiveReferralNotSuitableComments")] ArchiveReferral archiveReferral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archiveReferral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(archiveReferral);
        }

        // GET: ArchiveReferrals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archiveReferral = await _context.ArchiveReferral.FindAsync(id);
            if (archiveReferral == null)
            {
                return NotFound();
            }
            return View(archiveReferral);
        }

        // POST: ArchiveReferrals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArchiveReferralId,ArchiveReferralName,ArchiveReferralGenderId,ArchiveReferralLocalAuthorityId,ArchiveReferralReceivedDate,ArchiveReferralAge,ArchiveReferralComments,ArchiveReferralStatusId,ArchiveReferralSuitable,ArchiveReferralArchiveReasonId,ArchiveReferralSuitableComments,ArchiveReferralNotSuitableComments")] ArchiveReferral archiveReferral)
        {
            if (id != archiveReferral.ArchiveReferralId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archiveReferral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchiveReferralExists(archiveReferral.ArchiveReferralId))
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
            return View(archiveReferral);
        }

        // GET: ArchiveReferrals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archiveReferral = await _context.ArchiveReferral
                .FirstOrDefaultAsync(m => m.ArchiveReferralId == id);
            if (archiveReferral == null)
            {
                return NotFound();
            }

            return View(archiveReferral);
        }

        // POST: ArchiveReferrals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archiveReferral = await _context.ArchiveReferral.FindAsync(id);
            _context.ArchiveReferral.Remove(archiveReferral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchiveReferralExists(int id)
        {
            return _context.ArchiveReferral.Any(e => e.ArchiveReferralId == id);
        }
    }
}
