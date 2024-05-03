using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.ValueObjects;

public class SubscriptionId: ValueObject
{
    // ReSharper disable once MemberCanBePrivate.Global
    public Guid Value { get; private init; }
    
    
    private SubscriptionId() {}

    private SubscriptionId(Guid value)
    {
        Value = value;
    }

    public static SubscriptionId CreateNew() => new(Guid.NewGuid());
    public static SubscriptionId Parse(Guid id) => new(id);
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}