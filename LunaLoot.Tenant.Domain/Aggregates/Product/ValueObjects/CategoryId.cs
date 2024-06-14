using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;

public class CategoryId: ValueObject
{
    public Guid Value { get; init; }

    public CategoryId(Guid value)
    {
        Value = value;
    }

    public CategoryId()
    {
        Value = Guid.NewGuid();
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}