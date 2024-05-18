using System.Reflection;
using EntityFramework.Exceptions.PostgreSQL;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Domain.Aggregates.AccountAggregate;
using LunaLoot.Master.Domain.Aggregates.AccountAggregate.Entities;
using LunaLoot.Master.Domain.Aggregates.AddressAggregate;
using LunaLoot.Master.Domain.Aggregates.InvoiceAggregate;
using LunaLoot.Master.Domain.Aggregates.InvoiceAggregate;
using LunaLoot.Master.Domain.Aggregates.ProductAggregate;
using LunaLoot.Master.Domain.Aggregates.ProductAggregateRoot;
using LunaLoot.Master.Domain.Common.Interfaces;
using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Domain.Identity.Enums;
using LunaLoot.Master.Domain.Identity.ValueObjects;
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

        var administratorRole = IdentityRole.CreateNew(
            name: "Administrator",
            description: "Administrator user of application",
            weight: 999,
            permissions: Permissions.All,
            null
        );

        var tenantRole = IdentityRole.CreateNew(
            name: "Tenant",
            description: "Tanants of the application",
            weight: 1,
            permissions: Permissions.None,
            null);
        
        
        var anonymousRole = IdentityRole.CreateNew(
            name: "anonymous",
            description: "Anonymous user of application",
            weight: 0,
            permissions: Permissions.None,
            null
        );

        var administratorUser = IdentityUser.Create(
            IdentityUserId.CreateNew(),
            "administrator@master.lunaloot",
            "12345678910",
            PasswordHash.GenerateHashedPassword("administrator"),
            null
        );

        var administratorUserRole =
            new IdentityUserRole(IdentityUserRoleId.CreateNew(), administratorUser.Id, administratorRole.Id);
        
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        modelBuilder.Entity<IdentityRole>().HasData(
            data: [ administratorRole, tenantRole, anonymousRole ]
        );

        modelBuilder.Entity<IdentityUser>().HasData(
            data:  [administratorUser]
        );


        modelBuilder.Entity<IdentityUserRole>().HasData(
            data: administratorUserRole
        );
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseExceptionProcessor()
            .AddInterceptors(publishDomainEventInterceptor);
        base.OnConfiguring(optionsBuilder);
    }


}