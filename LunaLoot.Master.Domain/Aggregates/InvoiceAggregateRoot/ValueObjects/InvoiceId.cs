using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.InvoiceAggregateRoot.ValueObjects;

public sealed class InvoiceId(string value) : AggregateRootId<string>
{
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string Value { get; protected set; } = value;
}