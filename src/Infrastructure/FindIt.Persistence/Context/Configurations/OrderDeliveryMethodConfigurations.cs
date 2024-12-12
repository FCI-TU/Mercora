using FindIt.Domain.OrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindIt.Persistence.Context.Configurations;
public class OrderDeliveryMethodConfigurations : IEntityTypeConfiguration<OrderDeliveryMethod>
{
    public void Configure(EntityTypeBuilder<OrderDeliveryMethod> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.Cost)
         .HasColumnType("decimal(18,2)");

        builder.Property(p => p.DeliveryTime)
                  .IsRequired()
                  .HasMaxLength(50);
    }
}