using Components.Configuration;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Components
{
    public class OrganizationDbContext : DbContext
    {
        public DbSet<Organization> Organization { get; private set; } = default;

        public OrganizationDbContext(DbContextOptions options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Organization>(
                new OrganizationConfiguration());

            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }
    }
}
