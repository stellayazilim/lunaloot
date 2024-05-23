using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Common.References;
public class AddInRef(
    Guid value): ValueObject
{
    public Guid Value { get; private init; } = value;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}