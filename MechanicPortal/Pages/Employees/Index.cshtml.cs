using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MechanicPortal.Data;
using MechanicPortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MechanicPortal.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly MechanicPortal.Data.MechanicPortalContext _context;

        public IndexModel(MechanicPortal.Data.MechanicPortalContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? LastName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FullName { get; set; }

        public async Task OnGetAsync()
        {
            var employees = from e in _context.Employee
                           select e;
            if (!string.IsNullOrEmpty(SearchString))
            {
                employees = employees.Where(s => s.LastName.Contains(SearchString));
            }
            Employee = await employees.ToListAsync();
        }
    }
}
