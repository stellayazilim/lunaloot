using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Domain.Identity.Enums;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Tenant.Infrastructure.Identity;

public class LunaLootTenantIdentityDbContext(DbContextOptions<
    LunaLootTenantIdentityDbContext> options): 
    IdentityDbContext<
        ApplicationUser, 
        ApplicationRole, 
        Guid>(options)
{
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("identity");

        modelBuilder.Entity<ApplicationRole>().Property(x => x.Permissions)
            .HasConversion(
                perms => string.Join(',', perms),
                value => value.Split(',', StringSplitOptions
                    .RemoveEmptyEntries)
                    .ToList()
                    .ConvertAll(Enum.Parse<ApplicationPermissions>)
            );
        base.OnModelCreating(modelBuilder);
    }

}