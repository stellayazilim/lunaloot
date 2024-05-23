using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.ValueObjects;
using LunaLoot.Tenant.Domain.Common.Primitives;


namespace LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.Entities;

public class ProductVariant: Entity<ProductVariantId>
{
    #pragma warning disable CS8618 
    public ProductVariant() {}
    #pragma warning restore CS8618 
    
    public ProductVariant(
        ProductVariantId id,
        ProductId productId,
        Product product,
        ProductId variantId,
        Product variant) : base(id)
    {
        ProductId = productId;
        Product = product;
        VariantId = variantId;
        Variant = variant;
    }

    public ProductId ProductId { get; private init; }
    public Product Product { get; private init; } 

    public ProductId VariantId { get; private init; }
    public Product Variant { get; private init; }
}