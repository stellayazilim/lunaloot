using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

// ReSharper disable once ClassNeverInstantiated.Global
public class SubscriptionIdRef(Guid value): ValueObject
{
    public Guid Value { get; } = value;


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}