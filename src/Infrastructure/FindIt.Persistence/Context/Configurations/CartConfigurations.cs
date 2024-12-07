using FindIt.Domain.IdentityEntities;
using FindIt.Domain.CartEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindIt.Persistence.Context.Configurations
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            // Primary Key
            builder.HasKey(c => c.Id);

            // Configure Foreign Key property
            builder.Property(c => c.UserId)
                   .IsRequired()
                   .HasMaxLength(450);

            // Relationship With AppUser (One-to-One)
            builder.HasOne(c => c.AppUser)
                   .WithOne(u => u.Cart)
                   .HasForeignKey<Cart>(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            //// Relationship With CartItems (One-to-Many)
            //builder.HasMany(c => c.CartItems)
            //    .WithOne(ci => ci.Cart)
            //    .HasForeignKey(ci => ci.CartId)
            //    .OnDelete(DeleteBehavior.Cascade); 

        }
    }
}
