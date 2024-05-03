using LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;

namespace LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.Entities;

public class Subscription: Entity<SubscriptionId>
{
    #pragma warning disable CS8618
    private Subscription() {}
    #pragma warning restore CS8618  
    private Subscription(
        SubscriptionId id,
        DateTime validUntil,
        InvoiceIdRef invoiceId,
        AccountId accountId,
        Account account
    ) : base(id)
    {
        ValidUntil = validUntil;
        AccountId = accountId;
        Account = account;
        InvoiceId = invoiceId;
    }

    public static Subscription Create(
        SubscriptionId id,
        DateTime validUntil,
        InvoiceIdRef invoiceId,
        AccountId accountId,
        Account account) => new(id, validUntil, invoiceId, accountId, account);
    
    
    public DateTime ValidUntil { get; init; }
    public InvoiceIdRef InvoiceId { get; init; }
    public AccountId AccountId { get; init; }
    public Account Account { get; init; }
}