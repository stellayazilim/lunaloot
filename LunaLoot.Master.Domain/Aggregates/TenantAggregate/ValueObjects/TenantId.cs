using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.TenantAggregateRoot.ValueObjects;

public sealed class TenantId: AggregateRootId<Guid>
{
    public TenantId() {}

    public TenantId(Guid value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        // ReSharper disable once HeapView.BoxingAllocation
        yield return Value;
    }

    public override Guid Value { get; protected set; }
}