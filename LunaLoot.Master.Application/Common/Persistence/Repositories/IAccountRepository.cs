using LunaLoot.Master.Domain.AccountAggregateRoot;
using LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot;
using LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.ValueObjects;

namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

public interface IAccountRepository: IRepository<Account, AccountId>
{
    Account? GetByEmail(string email);
    Task<Account?> GetByEmailAsync(string email, CancellationToken? cancellationToken = null);
}