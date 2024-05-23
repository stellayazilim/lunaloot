using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.ValueObjects;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.Entities;

public class ProductAddIn : Entity<ProductAddinId> {
    
    #pragma warning disable CS8618 
    public ProductAddIn() {}
    #pragma warning restore CS8618 
    
    public ProductAddIn(
        ProductAddinId id,
        string name,
        string description,
        decimal price,
        float tax,
        bool included,
        bool canAdd,
        bool canRemove,
        List<Product>? products): base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Tax = tax;
        IncludedByDefault = included;
        CanAdd = canAdd;
        CanRemove = canRemove;
        _products = products ?? new();
    }
    public string Name { get; set; }
    public string Description { get; set; }

    public decimal Price { get; set; } 
    public float Tax { get; set; } 

    public bool IncludedByDefault { get; set; }

    public bool CanAdd { get; set; }
    public bool CanRemove { get; set; }

    private List<Product> _products = [];
    public IReadOnlyList<Product> Products => _products.AsReadOnly();

}