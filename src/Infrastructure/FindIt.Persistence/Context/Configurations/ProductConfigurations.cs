using FindIt.Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindIt.Persistence.Context.Configurations
{
    class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Primary Key
            builder.HasKey(p => p.Id);

            // Property Configurations
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(255);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Status)
                .HasMaxLength(50);

            // Relationship With Category
            //builder.HasOne(p => p.Category)
            //    .WithMany(c => c.Product)
            //    .HasForeignKey(p => p.CategoryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Relationship With Brand
            //builder.HasOne(p => p.Brand)
            //  .WithMany(b => b.Product)
            //  .HasForeignKey(p => p.BrandId)
            //  .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
