using Microsoft.EntityFrameworkCore;
using MechanicPortal.Models;

namespace MechanicPortal.Data
{
    public class MechanicPortalContext : DbContext
    {
        public MechanicPortalContext(DbContextOptions<MechanicPortalContext> options)
            : base(options)
        {
        }

        public DbSet<MechanicPortal.Models.Vehicle> Vehicle { get; set; } = default!;
        public DbSet<MechanicPortal.Models.Employee> Employee { get; set; } = default!;
    }
}
