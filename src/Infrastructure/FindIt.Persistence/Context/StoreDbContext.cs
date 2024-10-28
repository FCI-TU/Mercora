using FindIt.Domain.IdentityEntities;
using FindIt.Persistence.Context.Configurations;
using FindIt.Persistence.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FindIt.Persistence.Context
{
    public class StoreDbContext(DbContextOptions<StoreDbContext> options) : IdentityDbContext<AppUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppUserConfigurations).Assembly);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<IdentityCode> IdentityCodes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

    }
}
