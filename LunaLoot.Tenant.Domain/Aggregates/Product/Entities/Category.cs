using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.Product.Entities;

public class Category: Entity<CategoryId>
{
    public Category(CategoryId id): base(id)
    {
        
    }
    public Category()
    {
        
    }
}