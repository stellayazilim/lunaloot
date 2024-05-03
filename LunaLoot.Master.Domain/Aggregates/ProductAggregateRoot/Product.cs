using LunaLoot.Master.Domain.Aggregates.ProductAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;

namespace LunaLoot.Master.Domain.Aggregates.ProductAggregateRoot;

public class Product: AggregateRoot<ProductId, Guid>
{


    #region Constructors
    #pragma warning disable CS8618
    private Product() {}
    #pragma warning restore CS8618 
    private Product(
        ProductId id, 
        string name, 
        string description,
        Price price,
        Product? parent,
        ProductIdRef parentId,
        List<Product>? variants) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Parent = parent;
        ParentRef = parentId;
        _variants = variants ?? [];
    }
    #endregion

    #region Static factory
    public static Product Create(
        ProductId id, 
        string name, 
        string description,
        Price price,
        Product? parent,
        ProductIdRef parentId,
        List<Product>? variants) => new(id, name, description, price, parent, parentId, variants);

    #endregion
    public string Name { get; set; }
    public string Description { get; set; }
    public Price Price { get; set; }
    
    #region Variants
    // ReSharper disable once CollectionNeverUpdated.Local
    private readonly List<Product> _variants = [];
    public IReadOnlyList<Product> Variants => _variants.AsReadOnly();
    
    public Product? Parent { get; init; }
    public ProductIdRef? ParentRef { get; init; }
    public void AddVariant(Product variant)
    {
        _variants.Add(variant);
    }
    #endregion
 
}