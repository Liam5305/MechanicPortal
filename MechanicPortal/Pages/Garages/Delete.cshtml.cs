﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly MechanicPortal.Data.MechanicPortalContext _context;

        public DeleteModel(MechanicPortal.Data.MechanicPortalContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garage = await _context.Garage.FindAsync(id);
            if (garage != null)
            {
                Garage = garage;
                _context.Garage.Remove(Garage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
