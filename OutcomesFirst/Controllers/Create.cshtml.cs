using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OutcomesFirst.Data;
using OutcomesFirst.Models;

namespace OutcomesFirst.Controllers
{
    public class CreateModel : PageModel
    {
        private readonly OutcomesFirst.Data.ApplicationDbContext _context;

        public CreateModel(OutcomesFirst.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlacementGenderId"] = new SelectList(_context.Gender, "GenderId", "GenderId");
        ViewData["PlacementLeavingReasonId"] = new SelectList(_context.LeavingReason, "LeavingReasonId", "LeavingReasonId");
        ViewData["PlacementLocalAuthorityId"] = new SelectList(_context.LocalAuthority, "LocalAuthorityId", "LocalAuthorityId");
        ViewData["PlacementServiceId"] = new SelectList(_context.Service, "ServiceId", "ServiceId");
            return Page();
        }

        [BindProperty]
        public Placement Placement { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Placement.Add(Placement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}