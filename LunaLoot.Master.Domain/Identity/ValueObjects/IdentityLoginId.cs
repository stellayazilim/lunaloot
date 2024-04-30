using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Identity.ValueObjects;

public class IdentityLoginId: ValueObject
{   
    private IdentityLoginId() {}
    private IdentityLoginId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; private init; }

    
    
    
 
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static IdentityLoginId CreateNew() => new(Guid.NewGuid());

    public static IdentityLoginId Parse(Guid value) => new(value);
}