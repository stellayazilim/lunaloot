using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

public class IdentityUserIdRef: ValueObject
{
    public Guid Value { get; private set; }
    
    private IdentityUserIdRef() {}

    private IdentityUserIdRef(Guid id)
    {
        Value = id;
    }

    public static IdentityUserIdRef CreateFromId(IdentityUserId id) => new(id.Value);
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}