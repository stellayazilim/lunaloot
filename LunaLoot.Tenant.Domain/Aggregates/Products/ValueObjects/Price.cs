using LunaLoot.Tenant.Domain.Aggregates.Products.Enums;
using LunaLoot.Tenant.Domain.Common.Primitives;

namespace LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;

public sealed class Price : ValueObject
{
    private Price(
        Currency currency, decimal amount)
    {
        Amount = amount;
        Currency = currency;
    }
    
    private Price() {}

    public static Price Create(Currency currency, decimal amount) => new(currency, amount);
    public decimal Amount { get; init; } 
    public Currency Currency { get; init; } 

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}