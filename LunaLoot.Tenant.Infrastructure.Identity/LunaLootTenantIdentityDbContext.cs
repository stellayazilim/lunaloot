using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Domain.Identity.Enums;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Tenant.Infrastructure.Identity;

public class LunaLootTenantIdentityDbContext(DbContextOptions<LunaLootTenantIdentityDbContext> options): IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("identity");

        modelBuilder.Entity<ApplicationRole>().Property(x => x.Permissions)
            .HasConversion(
                perms => string.Join(',', perms),
                value => value.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(Enum.Parse<ApplicationPermissions>)
            );
        base.OnModelCreating(modelBuilder);
    }


    public static async Task Seed(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
    {
        
        await Task.CompletedTask;
        var adminstratorUser = ApplicationUser.CreateNew(
            Guid.NewGuid(),
            "administrator@lunaloot",
            "administrator"
        );
        var passwordHasher = new PasswordHasher<ApplicationUser>();
        await userManager.CreateAsync(
            adminstratorUser,
            passwordHasher.HashPassword(adminstratorUser, "administrator")
        );

        var administratorRole = ApplicationRole.CreateNew(
                Guid.NewGuid(),
                "administrator",
                [
                    ApplicationPermissions.All
                ]
            );
        var userRole = ApplicationRole.CreateNew(
            Guid.NewGuid(),
            "user",
            [ApplicationPermissions.None]
        );
        await roleManager.CreateAsync(administratorRole);
        await roleManager.CreateAsync(userRole);
        await userManager.AddToRoleAsync(adminstratorUser, "administrator");
    }
}