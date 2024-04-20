using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Auth.ValueObjects;

public class ApplicationClaimId: ValueObject
{
    public Guid Value { get; }

    private ApplicationClaimId(Guid id)
    {
        Value = id;
    }
    
    public static ApplicationClaimId CreateNew() => new(Guid.NewGuid());
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}