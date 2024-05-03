using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Identity.ValueObjects;
// ReSharper disable MemberCanBePrivate.Global

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

public class IdentityUserIdRef: ValueObject
{
    public Guid Value { get; private init; }
    
    public IdentityUserIdRef() {}

    public IdentityUserIdRef(Guid id)
    {
        Value = id;
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}