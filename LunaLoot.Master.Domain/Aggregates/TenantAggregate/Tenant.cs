using LunaLoot.Master.Domain.Aggregates.AccountAggregate.Entities;
using LunaLoot.Master.Domain.Aggregates.TenantAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;

namespace LunaLoot.Master.Domain.Aggregates.TenantAggregate;

public class Tenant: AggregateRoot<TenantId,Guid>
{
    public AccountIdRef AccountIdRef { get; set; }

    

    private List<Subscription> _subscriptions = new();
    public IReadOnlyList<Subscription> Subscriptions => _subscriptions.AsReadOnly();

    private List<AddressIdRef> _addresses = new();
    public IReadOnlyList<AddressIdRef> Addresses => _addresses.AsReadOnly();
    
    
    private Tenant() {}

    private Tenant(
        TenantId id,
        AccountIdRef accountIdRef,
        List<Subscription> subscriptions,
        List<AddressIdRef> addresses) : base(id)
    {
        AccountIdRef = accountIdRef;
        _subscriptions = subscriptions;
        _addresses = addresses;
    }
}