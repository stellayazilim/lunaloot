using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.AddressAggregateRoot.ValueObjects;

public class AddressId: AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private AddressId(Guid value)
    {
        Value = value;
    }
    
    private AddressId() {}

    public static AddressId CreateNew()
        => new(Guid.NewGuid());

    public static AddressId Parse(Guid id) => new(id);
}