using Microsoft.EntityFrameworkCore;

namespace MechanicPortal.Data
{
    public class MechanicPortalContext : DbContext
    {
        public MechanicPortalContext(DbContextOptions<MechanicPortalContext> options)
            : base(options)
        {
        }

        public DbSet<MechanicPortal.Models.Vehicle> Vehicle { get; set; } = default!;
    }
}
