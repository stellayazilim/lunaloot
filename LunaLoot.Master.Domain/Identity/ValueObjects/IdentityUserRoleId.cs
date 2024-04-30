using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Identity.ValueObjects;

public class IdentityUserRoleId: ValueObject
{
    private IdentityUserRoleId() { }

    private IdentityUserRoleId(Guid value)
    {
        Value = value;
    }

    public static IdentityUserRoleId CreateNew() => new(Guid.NewGuid());
    public static IdentityUserRoleId Parse(Guid id) => new(id);
    
    public Guid Value { get; private init;  }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}