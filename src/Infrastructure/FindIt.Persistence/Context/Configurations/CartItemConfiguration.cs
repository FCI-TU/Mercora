using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindIt.Persistence.Context.Configurations;
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            // Table name
            builder.ToTable("CartItems");

            // Primary Key
            builder.HasKey(ci => ci.Id);

            // Properties
            builder.Property(ci => ci.Id)
                   .ValueGeneratedOnAdd(); // Auto-increment

            builder.Property(ci => ci.ProductName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ci => ci.ProductImage)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(ci => ci.Quantity)
                   .IsRequired();

            builder.Property(ci => ci.UnitPrice)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)"); // Precision for currency

            builder.Property(ci => ci.Total)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)"); // Precision for currency

            // Relationships (if applicable)
            builder.HasOne<Cart>()
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(ci => ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade); // Define behavior on delete
        }
    }
}
