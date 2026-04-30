using SeedLibrary.Models.SeedViewModels;
using SeedLibrary.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeedLibrary.Models;

using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis.Scripting.Hosting;

namespace SeedLibrary.Pages.SpotlightSeeds;

public class SpotlightSeedsModel : PageModel
{
    private readonly SeedLibrary.Data.SeedContext _context;
    private readonly IConfiguration Configuration;
        public SpotlightSeedsModel(SeedContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public string NameSort { get; set; }
        public string YearSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Seed> Seeds { get;set; } = default!;
        public List<int> SelectedSeeds { get; set; } = new();

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            YearSort = sortOrder == "Year" ? "year_desc" : "Year";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Seed> seedsIQ = from s in _context.Seeds select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                seedsIQ = seedsIQ.Where(s => s.Name.Contains(searchString)
                                    || s.Variety.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    seedsIQ = seedsIQ.OrderByDescending(s => s.Name);
                    break;
                case "Year":
                    seedsIQ = seedsIQ.OrderBy(s => s.Year);
                    break;
                case "Year_desc":
                    seedsIQ = seedsIQ.OrderByDescending(s => s.Year);
                    break;
                default:
                    seedsIQ = seedsIQ.OrderBy(s => s.Name);
                    break;
            }


            var pageSize = Configuration.GetValue("PageSize", 5);
            Seeds = await PaginatedList<Seed>.CreateAsync(seedsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    
}