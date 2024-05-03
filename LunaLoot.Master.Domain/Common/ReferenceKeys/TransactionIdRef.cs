using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

public class TransactionIdRef
    (Guid value)
    : ValueObject
{
    public Guid Value { get; private init; } = value;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return value;
    }
}