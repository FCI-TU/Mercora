using FindIt.Domain.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindIt.Persistence.Context.Configurations;
internal class ProductSizeCofigurtaion : IEntityTypeConfiguration<ProductSize>
{
    public void Configure(EntityTypeBuilder<ProductSize> builder)
    {
        // Primary Key
        builder.HasKey(u => u.ProductId);

        builder.Property(u => u.SizeId)
            .IsRequired();
    }
}