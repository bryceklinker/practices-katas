using Microsoft.EntityFrameworkCore;

namespace Evercraft.Web.Common.Storage
{
    public class EvercraftContext : DbContext
    {
        public EvercraftContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EvercraftContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}