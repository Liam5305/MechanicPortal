using MechanicPortal.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MechanicPortal.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly MechanicPortal.Data.MechanicPortalContext _context;

        public IndexModel(MechanicPortal.Data.MechanicPortalContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicle { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Vehicle = await _context.Vehicle.ToListAsync();
        }
    }
}
