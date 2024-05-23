using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.Entities;
using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.ValueObjects;
using LunaLoot.Tenant.Domain.Common.Primitives;
using LunaLoot.Tenant.Domain.Common.References;

namespace LunaLoot.Tenant.Domain.Aggregates.ProductAggregate;

public class Product: AggregateRoot<ProductId, Guid>
{
    #pragma warning disable CS8618 
    public Product() {}
    #pragma warning restore CS8618 
    public Product(
        ProductId id,
        string name,
        string description,
        decimal price,
        float tax,
        BrandId? brandId,
        Brand? brand,
        List<KeyValuePair<string, string>>? specifications,
        List<ProductAddIn>? productAddIns,
        List<Product>? variants,
        ProductId? parentId,
        Product? parent) : base(id)
    {
        Name = name;
        BrandId = brandId;
        Brand = brand;
        Description = description;
        Price = price;
        Tax = tax;
        _specifications = specifications ?? new();
        _productAddIns = productAddIns ?? new();
        _variants = variants ?? new();
        ParentId = parentId;
        Parent = parent;
    }
    
    public string Name { get; set; }
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    public float Tax { get; set; }
    public BrandId? BrandId { get; set; }
    public Brand? Brand { get; set; }
    
    
    private readonly List<KeyValuePair<string, string>> _specifications;
    public IReadOnlyList<KeyValuePair<string, string>> Specifications => _specifications.AsReadOnly();
    
    private List<ProductAddIn> _productAddIns = [];
    public IReadOnlyList<ProductAddIn> ProductAddIns => _productAddIns.AsReadOnly();
    //
    // private readonly List<ProductVariant> _variants;
    // public IReadOnlyList<ProductVariant> Variants => _variants.AsReadOnly();

    private List<Product> _variants = [];
    public IReadOnlyList<Product> Variants => _variants.AsReadOnly();
    
    public ProductId? ParentId { get; set; }
    public Product? Parent { get; set; }
}