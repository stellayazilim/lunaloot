using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

public class InvoiceIdRef(string value) : ValueObject
{
    // ReSharper disable once MemberCanBePrivate.Global
    public string Value { get; private init; } = value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}