using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeedLibrary.Data;
using SeedLibrary.Models;

namespace SeedLibrary.Pages.Seeds
{
    public class DetailsModel : PageModel
    {
        private readonly SeedLibrary.Data.SchoolContext _context;

        public DetailsModel(SeedLibrary.Data.SchoolContext context)
        {
            _context = context;
        }

        public Seed Seed { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

                Seed = await _context.Seeds
        .Include(s => s.Enrollments)
        .ThenInclude(e => e.Course)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.ID == id);

            if (Seed is not null)
            {
                Seed = Seed;

                return Page();
            }

            return NotFound();
        }
    }
}
