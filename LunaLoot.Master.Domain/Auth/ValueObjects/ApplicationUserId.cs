
using LunaLoot.Master.Domain.Common.Primitives;
namespace LunaLoot.Master.Domain.Auth.ValueObjects;

public class ApplicationUserId: ValueObject
{
    public Guid Value { get; private init;  }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private ApplicationUserId(Guid value)
    {
        Value = value;
    }
    
    public ApplicationUserId() {} 

    public static ApplicationUserId CreateNew() => new(Guid.NewGuid());
    public static ApplicationUserId Parse(Guid id) => new(id);
}