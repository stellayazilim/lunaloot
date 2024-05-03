using LunaLoot.Master.Domain.Aggregates.ProductAggregateRoot.Enum;
using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.ProductAggregateRoot.ValueObjects;

public class Price(
    decimal value, 
    CurrencyType? currencyType) : ValueObject
{
    public decimal Value { get; set; } = value;

    public CurrencyType CurrencyType { get; set; } = currencyType ?? CurrencyType.Default;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return currencyType ?? CurrencyType.Default;
    }
}