using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutcomesFirst.Models;
using OutcomesFirst.Data;
using AutoMapper;
using OutcomesFirst.ViewModels;

namespace OutcomesFirst.Controllers
{
    public class LocalAuthoritiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LocalAuthoritiesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: LocalAuthorities
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var outcomesFirstContext = _context.LocalAuthority
              .Include(r => r.LocalAuthorityRegion)
              .OrderBy(o => o.LocalAuthorityName);
             
            LocalAuthorityViewModel viewModel = new LocalAuthorityViewModel();

            var localAuthorities = await _context.LocalAuthority
                             .Include(r => r.LocalAuthorityRegion)
                            .OrderBy(o => o.LocalAuthorityName)
                            .ToArrayAsync();
            IEnumerable<LocalAuthorityViewModel> localauthorityVM = _mapper.Map<LocalAuthority[], IEnumerable<LocalAuthorityViewModel>>(localAuthorities);

            return View(localauthorityVM);
        }

       

        // GET: LocalAuthorities/Create
        public IActionResult Create()
        {
            LocalAuthorityViewModel viewModel = new LocalAuthorityViewModel();

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }

        // POST: LocalAuthorities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( LocalAuthorityViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                LocalAuthority model = new LocalAuthority();
                _mapper.Map(viewModel, model);

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }

        // GET: LocalAuthorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.LocalAuthority.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            LocalAuthorityViewModel viewModel = new LocalAuthorityViewModel();
            _mapper.Map(model, viewModel);

            PopulateDropDowns(viewModel);

            return View(viewModel);
        }

        // POST: LocalAuthorities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LocalAuthorityViewModel viewModel)
        {
            if (id != viewModel.LocalAuthorityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    LocalAuthority model = new LocalAuthority();
                    _mapper.Map(viewModel, model);

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalAuthorityExists(viewModel.LocalAuthorityId))
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

        // GET: LocalAuthorities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {                return NotFound();
            }

            var localAuthority = await _context.LocalAuthority
                .FirstOrDefaultAsync(m => m.LocalAuthorityId == id);
            if (localAuthority == null)
            {
                return NotFound();
            }

            return View(localAuthority);
        }

        // POST: LocalAuthorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localAuthority = await _context.LocalAuthority.FindAsync(id);
            _context.LocalAuthority.Remove(localAuthority);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalAuthorityExists(int id)
        {
            return _context.LocalAuthority.Any(e => e.LocalAuthorityId == id);
        }

        private void PopulateDropDowns(LocalAuthorityViewModel viewModel)
        {

            viewModel.regions = _context.Region.ToList();
        }
    }
}
