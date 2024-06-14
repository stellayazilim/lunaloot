using LunaLoot.Tenant.Domain.Common.Primitives;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;

public sealed class ProductId: AggregateRootId<Guid>
{

    private ProductId()
    {
        Value = Guid.NewGuid();
    }

    private ProductId(Guid value)
    {
        Value = value;
    }

    public static ProductId Create(Guid id) => new(id);
    public static ProductId Create() => new();
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public override Guid Value { get; protected set; }
}


