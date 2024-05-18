using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.OrderAggregate.ValueObjects;

public sealed class OrderId(
    Guid value
    ): AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; } = value;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}