using LunaLoot.Master.Domain.Common.Primitives;
// ReSharper disable MemberCanBePrivate.Global

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

public class AddressIdRef: ValueObject
{
    public Guid Value { get; private init; }
    
    public AddressIdRef() {}

    public AddressIdRef(Guid id)
    {
        Value = id;
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}