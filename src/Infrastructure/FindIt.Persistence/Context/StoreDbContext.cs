using FindIt.Domain.IdentityEntities;
using FindIt.Persistence.Context.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FindIt.Persistence.Context;
public class StoreDbContext(DbContextOptions<StoreDbContext> options) : IdentityDbContext<AppUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppUserConfigurations).Assembly);
    }

    public DbSet<IdentityCode> IdentityCodes { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
}