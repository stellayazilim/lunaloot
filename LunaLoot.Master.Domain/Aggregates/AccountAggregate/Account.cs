using LunaLoot.Master.Domain.Aggregates.AccountAggregate.Entities;
using LunaLoot.Master.Domain.Aggregates.AccountAggregate.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;

// ReSharper disable CollectionNeverUpdated.Local

namespace LunaLoot.Master.Domain.Aggregates.AccountAggregate;

public class Account: AggregateRoot<AccountId, Guid>
{

    #region Constructors
    #pragma warning disable CS8618 
    private Account() { }
    #pragma warning restore CS8618

    private Account(
        AccountId id,
        IdentityUserIdRef accountUserId,
        List<AddressIdRef> addresses,
        List<Subscription> subscriptions) : base(id)
    {
        AccountUserRef = accountUserId;
        _addresses = addresses;
        _subscriptions = subscriptions;
    }
    #endregion
    
    #region Static factory
    public static Account Create(
        AccountId id,
        IdentityUserIdRef accountUserId,
        List<AddressIdRef> addresses,
        List<Subscription> subscriptions) => new(
        id, accountUserId,addresses, subscriptions
    );

    #endregion

    #region Addresses
        private readonly List<AddressIdRef> _addresses  = new ();
        public IReadOnlyList<AddressIdRef> Addresses => _addresses.AsReadOnly();
        public void AddAddress(AddressIdRef address)
        {
            _addresses.Add(address);
        }
    #endregion

    #region Subscriptions
        private readonly List<Subscription> _subscriptions = new();
        public IReadOnlyList<Subscription> Subscriptions => _subscriptions.AsReadOnly();
        public void AddSubscription(Subscription subscription)
        {
            _subscriptions.Add(subscription);
        }

        public void RemoveSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    #endregion
    public IdentityUserIdRef AccountUserRef { get; init; }
}