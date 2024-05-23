using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Common.References;

public class BrandRef(
    Guid value): ValueObject
{
    public Guid Value { get; private init; } = value;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static implicit operator Guid(BrandRef brandRef) => brandRef.Value;
    public static implicit operator BrandRef(Guid value) => new BrandRef(value);
}