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
    public class RegionalManagersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RegionalManagersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: RegionalManagers
        public async Task<IActionResult> Index()
        {
            RegionalManagerViewModel viewModel = new RegionalManagerViewModel();

            var regionalManagers = await _context.RegionalManager.ToArrayAsync();

            IEnumerable<RegionalManagerViewModel> regionalManagerVM = _mapper.Map<RegionalManager[], IEnumerable<RegionalManagerViewModel>>(regionalManagers);

            return View(regionalManagerVM);

        }

     
        // GET: RegionalManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegionalManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( RegionalManagerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                RegionalManager model = new RegionalManager();
                _mapper.Map(viewModel, model);

                _context.Add(model);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: RegionalManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.RegionalManager.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            RegionalManagerViewModel viewModel = new RegionalManagerViewModel();
            _mapper.Map(model, viewModel);

            return View(viewModel);
        }

        // POST: RegionalManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  RegionalManagerViewModel viewModel)
        {
            if (id != viewModel.RegionalManagerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    RegionalManager model = new RegionalManager();
                    _mapper.Map(viewModel, model);

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionalManagerExists(viewModel.RegionalManagerId))
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

        // GET: RegionalManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.RegionalManager
                .FirstOrDefaultAsync(m => m.RegionalManagerId == id);
            if (model == null)
            {
                return NotFound();
            }

            RegionalManagerViewModel viewModel = new RegionalManagerViewModel();
            _mapper.Map(model, viewModel);

            return View(viewModel);
        }



        // POST: RegionalManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regionalManager = await _context.RegionalManager.FindAsync(id);
            _context.RegionalManager.Remove(regionalManager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionalManagerExists(int id)
        {
            return _context.RegionalManager.Any(e => e.RegionalManagerId == id);
        }
    }
}
