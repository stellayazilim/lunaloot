using System.Reflection;
using LunaLoot.Master.Domain.Address;
using LunaLoot.Master.Domain.Common.Interfaces;
using LunaLoot.Master.Infrastructure.Identity;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
// ReSharper disable NullableWarningSuppressionIsUsed

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore;

public class LunaLootMasterDbContext(
    PublishDomainEventInterceptor publishDomainEventInterceptor,
    DbContextOptions<LunaLootMasterDbContext> options) :IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{

    public DbSet<Address> Addresses => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(publishDomainEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}