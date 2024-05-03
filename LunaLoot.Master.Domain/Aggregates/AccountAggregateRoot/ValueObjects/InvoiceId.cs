using LunaLoot.Master.Domain.Common.Primitives;
using shortid;

namespace LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.ValueObjects;

public class InvoiceId: ValueObject
{
    public string Value { get; init; } = string.Empty;
    
    
    private InvoiceId() {}

    private InvoiceId(string id)
    {
        Value = id;
    }

    public static InvoiceId CreateNew() => new(ShortId.Generate());
    public static InvoiceId Parse(string id) => new(id);
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}