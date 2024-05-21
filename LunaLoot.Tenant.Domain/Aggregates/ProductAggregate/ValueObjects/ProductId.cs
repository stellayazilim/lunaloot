using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.ValueObjects;

public sealed class ProductId: AggregateRootId<Guid>
{
    
    public ProductId() {}

    public ProductId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override Guid Value { get; protected set; }
}