using LunaLoot.Master.Domain.Common.Primitives;
using shortid;

namespace LunaLoot.Master.Domain.Aggregates.InvoiceAggregate.ValueObjects;

public sealed class InvoiceId : AggregateRootId<string>
{

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public InvoiceId()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        
    }

    public InvoiceId(string value)
    {
        Value = value;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string Value { get; protected set; }

    public static InvoiceId CreateNew() => new(ShortId.Generate());
}