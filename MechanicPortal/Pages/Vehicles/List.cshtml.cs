using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MechanicPortal.Data;
using MechanicPortal.Models;

namespace MechanicPortal.Pages.Vehicles
{
    public class ListModel : PageModel
    {
        private readonly MechanicPortal.Data.MechanicPortalContext _context;

        public ListModel(MechanicPortal.Data.MechanicPortalContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Vehicle = await _context.Vehicle.ToListAsync();
        }
    }
}
