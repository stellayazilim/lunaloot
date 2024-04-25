using System.Reflection;
using LunaLoot.Master.Domain.Address;
using LunaLoot.Master.Domain.Common.Interfaces;
using LunaLoot.Master.Infrastructure.Identity;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shortid;

// ReSharper disable NullableWarningSuppressionIsUsed

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore;

/// <summary>
/// The luna loot master db context class
/// </summary>
/// <seealso cref="IdentityDbContext{ApplicationUser, ApplicationRole, string}"/>
public class LunaLootMasterDbContext(
    PublishDomainEventInterceptor publishDomainEventInterceptor,
    DbContextOptions<LunaLootMasterDbContext> options) :IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{
    /// <summary>
    /// Gets the value of the application roles
    /// </summary>
    public DbSet<ApplicationRole> ApplicationRoles => Set<ApplicationRole>();
    /// <summary>
    /// Gets the value of the application users
    /// </summary>
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
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
        modelBuilder.Entity<ApplicationUser>().Property(x => x.Id).ValueGeneratedOnAdd().HasDefaultValue(ShortId.Generate());
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
}