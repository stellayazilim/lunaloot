using LunaLoot.Tenant.Domain.Aggregates.Products.Enums;
using LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;

namespace LunaLoot.Tenant.Api.Contracts.Common;

public record PriceResponse
(Currency Currency, decimal Amount)
{
    public Currency Currency { get; set; } = Currency;

    public decimal Amount { get; set; } = Amount;

    public static implicit operator PriceResponse(Price price)
    {
        return new PriceResponse(
            price.Currency,
            price.Amount
        );
    }
}