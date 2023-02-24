using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Components.Configuration
{
    internal class OrganizationConfiguration
        : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.Property(o => o.Id).IsRequired();
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Name).IsRequired().HasMaxLength(256);
            builder.Property(o => o.Description).HasMaxLength(1024);
        }
    }
}
