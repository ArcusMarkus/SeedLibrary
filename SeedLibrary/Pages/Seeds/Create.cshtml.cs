using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeedLibrary.Data;
using SeedLibrary.Models;

namespace SeedLibrary.Pages.Seeds
{
    public class CreateModel : PageModel
    {
        private readonly SeedLibrary.Data.SchoolContext _context;

        public CreateModel(SeedLibrary.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Seed Seed { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptySeed = new Seed();

            if (await TryUpdateModelAsync<Seed>(
                emptySeed,
                "seed",   // Prefix for form value.
                s => s.Variety, s => s.Name, s => s.EnrollmentDate))
            {
                _context.Seeds.Add(emptySeed);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
