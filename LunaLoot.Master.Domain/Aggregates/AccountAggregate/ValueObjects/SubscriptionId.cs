using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.AccountAggregate.ValueObjects;

public class SubscriptionId: ValueObject
{
    // ReSharper disable once MemberCanBePrivate.Global
    public Guid Value { get; private init; }
    
    
    public SubscriptionId() {}

    public SubscriptionId(Guid value)
    {
        Value = value;
    }


    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}