using LunaLoot.Tenant.Domain.Aggregates.Product;
using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;

namespace LunaLoot.Tenant.Application.Common.Persistence.Repositories;

public interface IProductRepository: 
    IRepository<Product, ProductId>
{
    
}

