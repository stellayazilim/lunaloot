using System.Reflection;
using LunaLoot.Tenant.Domain.Aggregates.Product;
using LunaLoot.Tenant.Domain.Aggregates.Product.Entities;
using LunaLoot.Tenant.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore;

public class LunaLootTenantDbContext
    (DbContextOptions<LunaLootTenantDbContext> options): 
    DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("default");

        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        
        base.OnModelCreating(modelBuilder);
    }
}