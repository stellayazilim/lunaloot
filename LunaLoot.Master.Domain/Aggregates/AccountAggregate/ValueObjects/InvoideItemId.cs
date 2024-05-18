using LunaLoot.Master.Domain.Common.Primitives;
using shortid;

#pragma warning disable CS8618

namespace LunaLoot.Master.Domain.Aggregates.AccountAggregate.ValueObjects;

public class InvoiceItemId: ValueObject
{
    private InvoiceItemId() {}

    private InvoiceItemId(string id)
    {
        Value = id;
    }
    // ReSharper disable once MemberCanBePrivate.Global
    public string Value { get; private init;  }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static InvoiceItemId CreateNew() => new(ShortId.Generate());
    public static InvoiceItemId Parse(string id) => new(id);
}