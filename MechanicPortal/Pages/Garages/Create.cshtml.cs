using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MechanicPortal.Data;
using MechanicPortal.Models;

namespace MechanicPortal.Pages.Garages
{
    public class CreateModel : PageModel
    {
        private readonly MechanicPortal.Data.MechanicPortalContext _context;

        public CreateModel(MechanicPortal.Data.MechanicPortalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Garage Garage { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Garage.Add(Garage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
