using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.InvoiceAggregateRoot.ValueObjects;

public class InvoiceItemId(string value): ValueObject
{
    public string Value { get; set; } = value;
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}