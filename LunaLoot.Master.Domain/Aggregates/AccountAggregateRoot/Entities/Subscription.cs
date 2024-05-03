using LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;

namespace LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.Entities;

public class Subscription: Entity<SubscriptionId>
{
    private Subscription() {}
    private Subscription(SubscriptionId id): base(id) {}
    
    
    public DateTime ValidUntil { get; init; }
    public InvoiceId InvoiceId { get; init; }
    public AccountId AccountId { get; init; }
    public Account Account { get; init; }
}