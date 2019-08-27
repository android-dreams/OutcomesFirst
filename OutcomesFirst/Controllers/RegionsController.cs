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
    public class RegionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public RegionsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Regions
        public async Task<IActionResult> Index()
        {
           

            var outcomesFirstContext = _context.Region
               
             .Include(r => r.RegionalManager.RegionalManagerName);

            return View(await _context.Region.ToListAsync());
        }


        // GET: Regions/Create
        public IActionResult Create()
        {
            RegionViewModel viewModel = new RegionViewModel();

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Region model = new Region();
                _mapper.Map(viewModel, model);

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }

        // GET: Regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Region.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            RegionViewModel viewModel = new RegionViewModel();
            _mapper.Map(model, viewModel);

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegionViewModel viewModel)
        {
            if (id != viewModel.RegionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Region model = new Region();
                    _mapper.Map(viewModel, model);

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionExists(viewModel.RegionId))
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

        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Region
                .FirstOrDefaultAsync(m => m.RegionId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var region = await _context.Region.FindAsync(id);
            _context.Region.Remove(region);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionExists(int id)
        {
            return _context.Region.Any(e => e.RegionId == id);
        }

        private void PopulateDropDowns(RegionViewModel viewModel)
        {

            viewModel.regionalManagers = _context.RegionalManager.ToList();
        }
    }
}
