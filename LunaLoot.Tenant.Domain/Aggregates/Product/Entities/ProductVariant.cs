
using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.Product.Entities;

public class ProductVariant: Entity<ProductVariantId>
{
    
    #pragma warning disable CS8618 
    private ProductVariant() {}
    #pragma warning restore CS8618

    private ProductVariant(
        ProductVariantId id,
        string variantType,
        ProductId productId,
        Product product,
        string description): base(id)
    {
        VariantType = variantType;
        Product = product;
        ProductId = productId;
        Description = description;
    }

    public static ProductVariant Create(
        ProductVariantId id,
        string variantType,
        ProductId productId,
        Product product,
        string description) => new(
            id,
            variantType,
            productId,
            product,
            description
        );

    public ProductId ProductId { get; set; } = null!;
    public Product Product { get; set; } = null!;

    
    public string VariantType { get; set; } 
    public string Description { get; set; }
}