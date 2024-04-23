using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Auth.ValueObjects;

public class ApplicationRoleId: ValueObject
{
    public Guid Value { get; private init; }

    private ApplicationRoleId(Guid value)
    {
        Value = value;
    }
    
    /// <summary>
    /// Default constructor for efcore
    /// </summary>
    private ApplicationRoleId() {}
    
    /// <summary>
    /// Equality component <see cref="ValueObject"/>
    /// </summary>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static ApplicationRoleId CreateNew() 
        => new(Guid.NewGuid());

    public static ApplicationRoleId Parse(Guid id) => new(id);
}