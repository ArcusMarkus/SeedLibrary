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

            var Seed =  await _context.Seeds.FirstOrDefaultAsync(m => m.ID == id);
            if (Seed == null)
            {
                return NotFound();
            }
            Seed = Seed;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Seed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeedExists(Seed.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SeedExists(int id)
        {
            return _context.Seeds.Any(e => e.ID == id);
        }
    }
}
