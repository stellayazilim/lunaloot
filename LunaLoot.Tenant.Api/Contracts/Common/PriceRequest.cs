using LunaLoot.Tenant.Domain.Aggregates.Products.Enums;
using LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;

namespace LunaLoot.Tenant.Api.Contracts.Common;

public record PriceRequest
{
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }


    public PriceRequest(Currency currency, decimal amount)
    {
        Currency = currency;
        Amount = amount;
    }
 
}