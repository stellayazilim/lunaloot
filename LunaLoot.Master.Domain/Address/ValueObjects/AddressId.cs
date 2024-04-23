using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Address.ValueObjects;

public class AddressId: ValueObject
{
    public Guid Value { get; private init; }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}