using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.ProductAggregateRoot.ValueObjects;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ProductId(Guid value) : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; } = value;


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }


}