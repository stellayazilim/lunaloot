using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;

public class BrandId : ValueObject
{
    private BrandId(Guid value)
    {
        Value = value;
    }

    private BrandId()
    {
        Value = Guid.NewGuid();
    }

    public static BrandId Create() => new();
    public static BrandId Create(Guid id) => new(id); 
    public Guid Value { get; } 

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}