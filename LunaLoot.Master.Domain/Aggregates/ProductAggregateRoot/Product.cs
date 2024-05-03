using LunaLoot.Master.Domain.Aggregates.ProductAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;

namespace LunaLoot.Master.Domain.Aggregates.ProductAggregateRoot;

public class Product: AggregateRoot<ProductId, Guid>
{

 
    public Product(
        ProductId id, 
        string name, 
        string description,
        Price price,
        List<Product>? variants) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        _variants = variants ?? [];
    }
    
    public string Name { get; set; }
    public string Description { get; set; }

    public Price Price { get; set; }
    // ReSharper disable once CollectionNeverUpdated.Local
    private readonly List<Product> _variants = [];
    public IReadOnlyList<Product> Variants => _variants.AsReadOnly();
    public ProductIdRef? ParentRef { get; set; }
    
    
    public void AddVariant(Product variant)
    {
        _variants.Add(variant);
    }
}