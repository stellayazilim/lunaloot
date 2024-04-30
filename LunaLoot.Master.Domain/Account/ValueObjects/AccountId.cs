using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Account.ValueObjects;

public sealed class AccountId: AggregateRootId<Guid>
{
    
    private AccountId() {}

    private AccountId(Guid value)
    {
        Value = value;
    }

    public static AccountId CreateNew() => new(Guid.NewGuid());
    public static AccountId Parse(Guid id) => new(id);

    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }

    public override Guid Value { get; protected set; }
}