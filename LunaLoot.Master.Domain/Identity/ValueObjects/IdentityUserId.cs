using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Identity.ValueObjects;

public sealed class IdentityUserId: AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private IdentityUserId(Guid value)
    {
        Value = value;
    }

    public static IdentityUserId CreateNew() => new(Guid.NewGuid());

    public static IdentityUserId Parse(Guid value) => new(value);
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}