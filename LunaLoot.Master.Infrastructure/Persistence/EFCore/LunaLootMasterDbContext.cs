using System.Reflection;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Domain.Address;
using LunaLoot.Master.Domain.Common.Interfaces;
using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Interceptors;
using Microsoft.EntityFrameworkCore;
using shortid;
using IdentityRole = LunaLoot.Master.Domain.Identity.IdentityRole;
using IdentityUser = LunaLoot.Master.Domain.Identity.IdentityUser;

// ReSharper disable NullableWarningSuppressionIsUsed

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore;

/// <summary>
/// The luna loot master db context class
/// </summary>
/// <seealso cref="IdentityDbContext{ApplicationUser, ApplicationRole, string}"/>
public class LunaLootMasterDbContext(
    PublishDomainEventInterceptor publishDomainEventInterceptor,
    DbContextOptions<LunaLootMasterDbContext> options) : DbContext(options), ILunaLootMasterDbContext
{
    /// <summary>
    /// Gets the value of the application roles
    /// </summary>
    public DbSet<IdentityRole> IdentityRoles => Set<IdentityRole>();
    /// <summary>
    /// Gets the value of the application users
    /// </summary>
    public DbSet<IdentityUser> IdentityUsers => Set<IdentityUser>();


    public DbSet<IdentityLogin> IdentityLogins => Set<IdentityLogin>();

    public DbSet<IdentityUserRole> IdentityUserRoles => Set<IdentityUserRole>();
    /// <summary>
    /// Gets the value of the addresses
    /// </summary>
    public DbSet<Address> Addresses => Set<Address>();

    /// <summary>
    /// Ons the model creating using the specified model builder
    /// </summary>
    /// <param name="modelBuilder">The model builder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Ons the configuring using the specified options builder
    /// </summary>
    /// <param name="optionsBuilder">The options builder</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .AddInterceptors(publishDomainEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public Task<int> SaveChangesAsync(CancellationToken? cancellationToken)
    {
        return base.SaveChangesAsync(cancellationToken ?? CancellationToken.None);
    }

}