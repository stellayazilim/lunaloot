using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Auth.ValueObjects;

public class ApplicationRoleId: ValueObject
{
    public Guid Value { get;  }

    private ApplicationRoleId(Guid id)
    {
        Value = id;
    }

    public static ApplicationRoleId CreateNew() => new(Guid.NewGuid());
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}