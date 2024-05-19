using LunaLoot.Tenant.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore;

public class LunaLootTenantDbContext(DbContextOptions<LunaLootTenantDbContext> options): IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}