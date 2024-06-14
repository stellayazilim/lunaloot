using LunaLoot.Tenant.Application.Common.Persistence.Repositories;
using LunaLoot.Tenant.Domain.Aggregates.Product;
using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;
namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore.Repositories;

public class ProductRepository(LunaLootTenantDbContext dbContext)
:Repository<Product, ProductId>(dbContext), IProductRepository
{
    
}