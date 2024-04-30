using LunaLoot.Master.Domain.Account;
using LunaLoot.Master.Domain.Account.ValueObjects;

namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

public interface IAccountRepository: IRepository<Account, AccountId>
{
    Account? GetByEmail(string email);
    Task<Account?> GetByEmailAsync(string email, CancellationToken? cancellationToken = null);
}