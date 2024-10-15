using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MechanicPortal.Data;
using MechanicPortal.Models;

namespace MechanicPortal.Pages.Garages
{
    public class DetailsModel : PageModel
    {
        private readonly MechanicPortal.Data.MechanicPortalContext _context;

        public DetailsModel(MechanicPortal.Data.MechanicPortalContext context)
        {
            _context = context;
        }

        public Garage Garage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garage = await _context.Garage.FirstOrDefaultAsync(m => m.GarageId == id);
            if (garage == null)
            {
                return NotFound();
            }
            else
            {
                Garage = garage;
            }
            return Page();
        }
    }
}
