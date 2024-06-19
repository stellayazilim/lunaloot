using LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.Products.Entities;

public class Brand: Entity<BrandId>
{
    private Brand() {}

    private Brand(
        BrandId id,
        string name,
        string description,
        List<Product>? products) : base(id)
    {
        Name = name;
        Description = description;
        _products = products ?? new();
    }

    public static Brand Create(
        BrandId id,
        string name,
        string description,
        List<Product>? products
        ) => new(
            id,
            name,
            description,
            products
        );
    
    public string Name { get; set; }
    public string Description { get; set; }

    private List<Product> _products = [];
    public IReadOnlyList<Product> Products => _products.AsReadOnly();

}