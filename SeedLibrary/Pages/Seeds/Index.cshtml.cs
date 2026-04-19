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
    public class IndexModel : PageModel
    {
        private readonly SeedLibrary.Data.SchoolContext _context;

        public IndexModel(SeedLibrary.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Seed> Seed { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Seed = await _context.Seeds.ToListAsync();
        }
    }
}
