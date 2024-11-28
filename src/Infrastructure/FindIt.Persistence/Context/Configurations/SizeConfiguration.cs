using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindIt.Domain.IdentityEntities;

namespace FindIt.Infrastructure.Configurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        // Set primary key
        builder.HasKey(s => s.SizeId);
        
        builder.Property(s => s.Label)
            .IsRequired() // Ensures Label is not nullable
            .HasMaxLength(100); // Optional: set maximum length for Label
    }
}
