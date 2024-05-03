using System.Reflection;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot;
using LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.Entities;
using LunaLoot.Master.Domain.Aggregates.AddressAggregateRoot;
using LunaLoot.Master.Domain.Aggregates.InvoiceAggregateRoot;
using LunaLoot.Master.Domain.Aggregates.ProductAggregateRoot;
using LunaLoot.Master.Domain.Common.Interfaces;
using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations.InvoiceConfiguration;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Interceptors;
using Microsoft.EntityFrameworkCore;
using IdentityRole = LunaLoot.Master.Domain.Identity.IdentityRole;
using IdentityUser = LunaLoot.Master.Domain.Identity.IdentityUser;


namespace LunaLoot.Master.Infrastructure.Persistence.EFCore;


public class LunaLootMasterDbContext(
    PublishDomainEventInterceptor publishDomainEventInterceptor,
    DbContextOptions<LunaLootMasterDbContext> options) : DbContext(options), ILunaLootMasterDbContext
{

    public DbSet<IdentityRole> IdentityRoles => Set<IdentityRole>();

    public DbSet<IdentityUser> IdentityUsers => Set<IdentityUser>();
    
    public IEnumerable<IdentityLogin> IdentityLogins => Set<IdentityLogin>();

    public DbSet<IdentityUserRole> IdentityUserRoles => Set<IdentityUserRole>();

    public DbSet<Address> Addresses => Set<Address>();


    public DbSet<Account> Accounts => Set<Account>();

    public DbSet<Invoice> Invoices => Set<Invoice>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Subscription> Subscriptions => Set<Subscription>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .AddInterceptors(publishDomainEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }


}