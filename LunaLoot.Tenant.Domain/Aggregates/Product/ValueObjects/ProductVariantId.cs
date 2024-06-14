using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;

public class ProductVariantId: ValueObject
{
    public Guid Value { get; private init; }
    
    // ReSharper disable once ConvertToPrimaryConstructor
    private ProductVariantId(Guid value)
    {
        Value = value;
    }

    private ProductVariantId()
    {
        Value = Guid.NewGuid();
    }

    public static ProductVariantId Create(Guid id) => new(id);
    public static ProductVariantId Create() => new();
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}