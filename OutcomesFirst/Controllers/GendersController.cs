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
    public class GendersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GendersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: Genders
        public async Task<IActionResult> Index()
        {
            GenderViewModel viewModel = new GenderViewModel();

            var genders = await _context.Gender.ToArrayAsync();

            IEnumerable<GenderViewModel> gendersVM = _mapper.Map<Gender[], IEnumerable<GenderViewModel>>(genders);

            return View(gendersVM);
        }

        
        // GET: Genders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GenderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Gender model = new Gender();
                _mapper.Map(viewModel, model);

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Genders/Edit/5
       

        // POST: Genders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GenderViewModel viewModel)
        {
            if (id != viewModel.GenderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Gender model = new Gender();
                    _mapper.Map(viewModel, model);


                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenderExists(viewModel.GenderId))
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

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Gender
                .FirstOrDefaultAsync(m => m.GenderId == id);
            if (model == null)
            {
                return NotFound();
            }

            GenderViewModel viewModel = new GenderViewModel();
            _mapper.Map(model, viewModel);

            return View(viewModel);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Gender.FindAsync(id);
            _context.Gender.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenderExists(int id)
        {
            return _context.Gender.Any(e => e.GenderId == id);
        }
    }
}
