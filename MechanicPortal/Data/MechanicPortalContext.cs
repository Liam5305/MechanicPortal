using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MechanicPortal.Models;

namespace MechanicPortal.Data
{
    public class MechanicPortalContext : DbContext
    {
        public MechanicPortalContext (DbContextOptions<MechanicPortalContext> options)
            : base(options)
        {
        }

        public DbSet<MechanicPortal.Models.Vehicle> Vehicle { get; set; } = default!;
    }
}
