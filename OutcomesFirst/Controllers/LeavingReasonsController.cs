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
    public class LeavingReasonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LeavingReasonsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: LeavingReasons
        public async Task<IActionResult> Index()
        {
            LeavingReasonsViewModel viewModel = new LeavingReasonsViewModel();

            var leavingreasons = await _context.LeavingReason.ToArrayAsync();

            IEnumerable<LeavingReasonsViewModel> leavingReasonsVM = _mapper.Map<LeavingReason[], IEnumerable<LeavingReasonsViewModel>>(leavingreasons);

            return View(leavingReasonsVM);

        }


        // GET: LeavingReasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeavingReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeavingReasonsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                LeavingReason model = new LeavingReason();
                _mapper.Map(viewModel, model);

                _context.Add(model);

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: LeavingReasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.LeavingReason.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            LeavingReasonsViewModel viewModel = new LeavingReasonsViewModel();
            _mapper.Map(model, viewModel);


            return View(viewModel);
        }

        // POST: LeavingReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeavingReasonsViewModel viewModel)
        {
            if (id != viewModel.LeavingReasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    LeavingReason model = new LeavingReason();
                    _mapper.Map(viewModel, model);
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeavingReasonExists(viewModel.LeavingReasonId))
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
            return View(viewModel);
        }

        // GET: LeavingReasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.LeavingReason
                .FirstOrDefaultAsync(m => m.LeavingReasonId == id);
            if (model == null)
            {
                return NotFound();
            }

            LeavingReasonsViewModel viewModel = new LeavingReasonsViewModel();
            _mapper.Map(model, viewModel);

            return View(viewModel);
        }

        // POST: LeavingReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leavingReason = await _context.LeavingReason.FindAsync(id);
            _context.LeavingReason.Remove(leavingReason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeavingReasonExists(int id)
        {
            return _context.LeavingReason.Any(e => e.LeavingReasonId == id);
        }
    }
}
