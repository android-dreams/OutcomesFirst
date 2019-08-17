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
    public class StatusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StatusController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            return View(await _context.Status
                .OrderBy(o => o.StatusName)
                .ToListAsync());
        }

       

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Status model = new Status();
                _mapper.Map(viewModel, model);

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list = new SelectList(new[]
            {
                new { ID = "1", Name = "1" },
                new { ID = "2", Name = "2" },
                new { ID = "3", Name = "3" },
            },
            "ID", "Name", 1);

            ViewData["list"] = list;
          
            var model = await _context.Status.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            StatusViewModel viewModel = new StatusViewModel();
            _mapper.Map(model, viewModel);

            return View(viewModel);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StatusViewModel viewModel)
        {
            if (id != viewModel.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Status model = new Status();
                    _mapper.Map(viewModel, model);

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(viewModel.StatusId))
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

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var status = await _context.Status.FindAsync(id);
            _context.Status.Remove(status);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.StatusId == id);
        }
    }
}
