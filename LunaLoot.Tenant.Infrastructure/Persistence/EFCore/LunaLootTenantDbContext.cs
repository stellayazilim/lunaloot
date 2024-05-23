using System.Reflection;
using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate;
using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.Entities;
using LunaLoot.Tenant.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore;

public class LunaLootTenantDbContext
    (DbContextOptions<LunaLootTenantDbContext> options): 
    DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<ProductAddIn> ProductAddIns => Set<ProductAddIn>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("default");

        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        
        base.OnModelCreating(modelBuilder);
    }
}