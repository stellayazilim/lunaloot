using LunaLoot.Master.Domain.Aggregates.AccountAggregate;
using LunaLoot.Master.Domain.Aggregates.AccountAggregate.ValueObjects;

namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

public interface IAccountRepository: IRepository<Account, AccountId>
{
    Account? GetByEmail(string email);
    Task<Account?> GetByEmailAsync(string email, CancellationToken? cancellationToken = null);
}