// using LunaLoot.Master.Application.Common.Persistence.Repositories;
// using LunaLoot.Master.Domain.Account;
// using LunaLoot.Master.Domain.Account.ValueObjects;
// using LunaLoot.Master.Domain.Auth;
// using LunaLoot.Master.Domain.Auth.ValueObjects;
// using Microsoft.EntityFrameworkCore;
//
// namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;
//
// public class AccountRepository(LunaLootMasterDbContext dbContext) :
//     Repository<Account, AccountId>(dbContext), IAccountRepository
// {
//     public Account? GetByEmail(string email)
//     {
//         var users = _dbSet.Include(u => u.Roles);
//
//         return (from t
//                 in users
//             where t.Email == email
//             select t).FirstOrDefault();
//     }
//
//     public Task<ApplicationUser?> GetByEmailAsync(string email, CancellationToken? cancellationToken)
//     {
//         var users = (from user in _dbSet
//             where user.Email == email
//             select user);
//
//         return users
//             .Include(u => u.Roles)
//             .FirstOrDefaultAsync(cancellationToken ?? CancellationToken.None);
//     }
// }