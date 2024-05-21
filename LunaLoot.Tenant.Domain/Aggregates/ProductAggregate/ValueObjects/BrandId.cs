using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.ValueObjects;

public class BrandId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}