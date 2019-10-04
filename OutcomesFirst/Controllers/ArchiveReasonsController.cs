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
    public class ArchiveReasonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ArchiveReasonsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: ArchiveReasons
        public async Task<IActionResult> Index()
        {

            ArchiveReasonViewModel viewModel = new ArchiveReasonViewModel();

            var archiveReasons = await _context.ArchiveReason.ToArrayAsync();

            IEnumerable<ArchiveReasonViewModel> archiveReasonVM = _mapper.Map<ArchiveReason[], IEnumerable<ArchiveReasonViewModel>>(archiveReasons);


            return View(archiveReasonVM);

        }

        // GET: ArchiveReasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archiveReason = await _context.ArchiveReason
                .FirstOrDefaultAsync(m => m.ArchiveReasonId == id);
            if (archiveReason == null)
            {
                return NotFound();
            }

            return View(archiveReason);
        }

        // GET: ArchiveReasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArchiveReasons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArchiveReasonViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ArchiveReason model = new ArchiveReason();
                _mapper.Map(viewModel, model);

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: ArchiveReasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.ArchiveReason.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            ArchiveReasonViewModel viewModel = new ArchiveReasonViewModel();
            _mapper.Map(model, viewModel);

            return View(viewModel);
        }

        // POST: ArchiveReasons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArchiveReasonViewModel viewModel)
        {
            if (id != viewModel.ArchiveReasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ArchiveReason model = await _context.ArchiveReason.FindAsync(id);

                    _mapper.Map(viewModel, model);

                    _context.Update(model);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchiveReasonExists(viewModel.ArchiveReasonId))
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

        // GET: ArchiveReasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.ArchiveReason
                .FirstOrDefaultAsync(m => m.ArchiveReasonId == id);
            if (model == null)
            {
                return NotFound();
            }

            ArchiveReasonViewModel viewModel = new ArchiveReasonViewModel();
            _mapper.Map(model, viewModel);


            return View(viewModel);
        }

        // POST: ArchiveReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archiveReason = await _context.ArchiveReason.FindAsync(id);
            _context.ArchiveReason.Remove(archiveReason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchiveReasonExists(int id)
        {
            return _context.ArchiveReason.Any(e => e.ArchiveReasonId == id);
        }
    }
}
