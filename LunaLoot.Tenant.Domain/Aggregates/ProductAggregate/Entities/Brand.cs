using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.ValueObjects;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.Entities;

public class Brand: Entity<BrandId>
{
    public Brand() {}

    public Brand(
        BrandId id,
        string name,
        string description,
        List<Product>? products) : base(id)
    {
        Name = name;
        Description = description;
        _products = products ?? new();
    }
    
    public string Name { get; set; }
    public string Description { get; set; }

    private List<Product> _products = [];
    public IReadOnlyList<Product> Products => _products.AsReadOnly();

}