using LunaLoot.Tenant.Domain.Aggregates.Products;
using LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;

namespace LunaLoot.Tenant.Application.Common.Persistence.Repositories;

public interface IProductRepository: 
    IRepository<Product, ProductId>
{
    
}

