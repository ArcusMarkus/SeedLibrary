using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeedLibrary.Data;
using SeedLibrary.Models;

namespace SeedLibrary.Pages.Seeds
{
    public class EditModel : PageModel
    {
        private readonly SeedLibrary.Data.SchoolContext _context;

        public EditModel(SeedLibrary.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seed Seed { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Seed = await _context.Seeds.FindAsync(id);

        if (Seed == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var seedToUpdate = await _context.Seeds.FindAsync(id);

        if (seedToUpdate == null)
        {
            return NotFound();
        }

        if (await TryUpdateModelAsync<Seed>(
            seedToUpdate,
            "seed",
            s => s.Variety, s => s.Name, s => s.EnrollmentDate))
        {
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        return Page();
    }

        private bool SeedExists(int id)
        {
            return _context.Seeds.Any(e => e.ID == id);
        }
    }
}
