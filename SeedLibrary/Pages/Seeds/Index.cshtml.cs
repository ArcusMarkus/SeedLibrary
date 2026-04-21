using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeedLibrary.Data;
using SeedLibrary.Models;

namespace SeedLibrary.Pages.Seeds
{
    public class IndexModel : PageModel
    {
        private readonly SeedLibrary.Data.SchoolContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Seed> Seeds { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
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
                case "Date":
                    seedsIQ = seedsIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    seedsIQ = seedsIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    seedsIQ = seedsIQ.OrderBy(s => s.Name);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Seeds = await PaginatedList<Seed>.CreateAsync(seedsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
