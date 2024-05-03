using LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;

// ReSharper disable CollectionNeverUpdated.Local

namespace LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot;

public class Account: AggregateRoot<AccountId, Guid>
{
    #pragma warning disable CS8618 
    private Account() { }
    #pragma warning restore CS8618

    private Account(
        AccountId id,
        IdentityUserIdRef accountUserId,
        List<AddressIdRef> addresses,
        List<SubscriptionIdRef> subscriptions) : base(id)
    {
        AccountUserRef = accountUserId;
        _addresses = addresses;
        _subscriptions = subscriptions;
    }


    #region Addresses
        private readonly List<AddressIdRef> _addresses  = new ();
        public IReadOnlyList<AddressIdRef> Addresses => _addresses.AsReadOnly();
        public void AddAddress(AddressIdRef address)
        {
            _addresses.Add(address);
        }
    #endregion

    #region Subscriptions
        private readonly List<SubscriptionIdRef> _subscriptions = new();
        public IReadOnlyList<SubscriptionIdRef> Subscriptions => _subscriptions.AsReadOnly();
        public void AddSubscription(SubscriptionIdRef subscription)
        {
            _subscriptions.Add(subscription);
        }

        public void RemoveSubscription(SubscriptionIdRef subscription)
        {
            throw new NotImplementedException();
        }
    #endregion
    


    
    public IdentityUserIdRef AccountUserRef { get; init; }
}