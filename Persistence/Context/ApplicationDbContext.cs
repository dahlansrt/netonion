using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var now = DateTime.UtcNow;
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                    ((BaseEntity)entity.Entity).CreatedAt = now;

                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
