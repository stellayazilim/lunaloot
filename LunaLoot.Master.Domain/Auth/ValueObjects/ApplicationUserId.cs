
using LunaLoot.Master.Domain.Common.Primitives;
namespace LunaLoot.Master.Domain.Auth.ValueObjects;

public class ApplicationUserId: AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private ApplicationUserId(Guid value)
    {
        Value = value;
    }
    
    private  ApplicationUserId() {} 

    public static ApplicationUserId CreateNew() => new(Guid.NewGuid());
    public static ApplicationUserId Parse(Guid value) => new(value);
}