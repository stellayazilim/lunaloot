using System.ComponentModel.DataAnnotations;
using LunaLoot.Tenant.Domain.Aggregates.Product.Entities;
using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;
using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.Entities;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.Product;

public class Product: AggregateRoot<ProductId>
{
    
    #pragma warning disable CS8618 
    private Product() {}
    #pragma warning restore CS8618 
    private Product(
        ProductId id,
        string name,
        string description,
        Price? price,
        BrandId? brandId,
        Brand? brand,
        List<KeyValuePair<string, string>>? specifications,
        List<ProductVariant>? variants) : base(id)
    {
        Name = name;
        BrandId = brandId;
        Brand = brand;
        Price = price;
        Description = description;
        _specifications = specifications ?? new();
        _variants = variants ?? new();
    }

    public static Product Create(
        ProductId id,
        string name,
        string description,
        Price? price,
        BrandId? brandId,
        Brand? brand,
        List<KeyValuePair<string, string>>? specifications,
        List<ProductVariant>? variants) => new(
            id, name, description, price, brandId, brand, specifications, variants);
    
    [StringLength(255)]
    public string Name { get; private set; }
    
    [StringLength(255)]
    public string Description { get; private set; }
    
    public Price Price { get; private set; }
    public BrandId? BrandId { get; private set; }
    public Brand? Brand { get; private set; }
    
    
    private readonly List<KeyValuePair<string, string>> _specifications;
    public IReadOnlyList<KeyValuePair<string, string>> Specifications => _specifications.AsReadOnly();

    public Product AddSpecification(KeyValuePair<string, string> specification)
    {
        _specifications.Add(specification);
        return this;
    }

    public Product RemoveSpecification(KeyValuePair<string, string>  item)
    {
        _specifications.Remove(item);
        return this;
    }
    
    // private readonly List<ProductVariant> _variants;
    // public IReadOnlyList<ProductVariant> Variants => _variants.AsReadOnly();
    private List<ProductVariant> _variants = [];
    public IReadOnlyList<ProductVariant> Variants => _variants.AsReadOnly();

    public Product AddVariant(ProductVariant variant)
    {
        _variants.Add(variant);
        return this;
    }

    public Product RemoveVariant(ProductVariant variant)
    {
        _variants.Remove(variant);
        return this;
    }
}