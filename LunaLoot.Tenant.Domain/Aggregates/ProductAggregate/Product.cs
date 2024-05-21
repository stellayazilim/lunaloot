using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.ValueObjects;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.ProductAggregate;

public class Product: AggregateRoot<ProductId, Guid>
{
    public Product(ProductId id) : base(id)
    {
        
    }
    
    public string Name { get; set; }
    public string Brand { get; set; }
}