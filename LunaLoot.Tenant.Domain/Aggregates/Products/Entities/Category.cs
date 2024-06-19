using LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.Products.Entities;

public class Category: Entity<CategoryId>
{
    public Category(CategoryId id): base(id)
    {
        
    }
    public Category()
    {
        
    }
}