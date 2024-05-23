using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.ValueObjects;

public class ProductVariantId(
        Guid value
    ): ValueObject
{
    public Guid Value { get; private init; } = value;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}