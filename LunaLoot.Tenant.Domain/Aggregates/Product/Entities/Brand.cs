using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.Entities;

public class Brand: Entity<BrandId>
{
    private Brand() {}

    private Brand(
        BrandId id,
        string name,
        string description,
        List<Product.Product>? products) : base(id)
    {
        Name = name;
        Description = description;
        _products = products ?? new();
    }

    public static Brand Create(
        BrandId id,
        string name,
        string description,
        List<Product.Product>? products
        ) => new(
            id,
            name,
            description,
            products
        );
    
    public string Name { get; set; }
    public string Description { get; set; }

    private List<Product.Product> _products = [];
    public IReadOnlyList<Product.Product> Products => _products.AsReadOnly();

}