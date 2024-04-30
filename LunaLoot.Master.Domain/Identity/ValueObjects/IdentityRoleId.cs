using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Identity.ValueObjects;

public class IdentityRoleId: AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
   
    private IdentityRoleId() {}

    private IdentityRoleId(Guid value)
    {
        Value = value;
    }

    public static IdentityRoleId CreateNew() => new(Guid.NewGuid());
    public static IdentityRoleId Parse(Guid value) => new(value);
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}