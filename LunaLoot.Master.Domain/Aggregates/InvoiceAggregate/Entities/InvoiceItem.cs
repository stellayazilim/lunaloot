using LunaLoot.Master.Domain.Aggregates.InvoiceAggregate.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using InvoiceId = LunaLoot.Master.Domain.Aggregates.AccountAggregate.ValueObjects.InvoiceId;

namespace LunaLoot.Master.Domain.Aggregates.InvoiceAggregate.Entities;

// ReSharper disable once ClassNeverInstantiated.Global
public class InvoiceItem(
    InvoiceItemId id,
    ushort amount,
    float pricePerUnit,
    
    ProductIdRef productIdRef): Entity<InvoiceItemId>(id)
{
    public ProductIdRef ProductId { get; set; } = productIdRef;
    
    // Amount of unit
    public ushort Amount { get; set; } = amount;
     
    // Price of unit
    public double PricePerUnit { get; set; } = pricePerUnit;
    
    // Amount * PricePerUnit
    public decimal Price => (decimal)(PricePerUnit * Amount);
    
    
    public required InvoiceId InvoiceId { get; set; }
    public required Invoice Invoice { get; set; }
}