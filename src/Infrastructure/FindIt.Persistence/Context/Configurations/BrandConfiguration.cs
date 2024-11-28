using FindIt.Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindIt.Persistence.Context.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(p => p.Name)
           .IsRequired()
           .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired()
           .HasMaxLength(100);
            builder.Property(p => p.LogUrl)
                .IsRequired(false)
           .HasMaxLength(100);
        }

    }
}

