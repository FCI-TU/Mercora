using FindIt.Domain.OrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FindIt.Persistence.Context.Configurations
{
    internal class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(Order => Order.ShippingAddress, ShippingAddress =>
            {
                ShippingAddress.Property(sa => sa.FirstName)
                      .IsRequired()
                      .HasMaxLength(50);

                ShippingAddress.Property(sa => sa.LastName)
                      .IsRequired()
                      .HasMaxLength(50);

                ShippingAddress.Property(sa => sa.Street)
                      .IsRequired()
                      .HasMaxLength(100);

                ShippingAddress.Property(sa => sa.City)
                      .IsRequired()
                      .HasMaxLength(50);

                ShippingAddress.Property(sa => sa.Country)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            builder.Property(o => o.BuyerEmail)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o=>o.OrderDate)
                .HasMaxLength(50);

            builder.Property(o => o.SubTotal)
                .HasColumnType("decimal(9,2)");
        }
    }
}
