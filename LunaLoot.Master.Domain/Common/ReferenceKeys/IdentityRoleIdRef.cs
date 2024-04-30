using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

public class IdentityRoleIdRef: ValueObject
{
    public Guid Value { get; private set; }
    
    private IdentityRoleIdRef() {}

    private IdentityRoleIdRef(Guid id)
    {
        Value = id;
    }

    public static IdentityRoleIdRef CreateFromId(IdentityRoleId roleId) => new(roleId.Value); 
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;

    }
}