using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using LunaLoot.Master.Infrastructure.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Identity.Services;

public class UserManager(LunaLootMasterDbContext dbContext): IUserManager, IDisposable
{

    private  DbSet<IdentityUser> UserSet => dbContext.IdentityUsers;


    #region Create User

        public void CreateUser(IdentityUser user)
        {
            UserSet.Add(user);
        }

        public async Task CreateUserAsync(IdentityUser user)
        {
            await UserSet.AddAsync(user);
        }
        
    #endregion


    #region Get User
    
        public async Task<IdentityUser?> GetUserByIdAsync(IdentityUserId id)
        {
            return await UserSet.FindAsync(id);
        }
        
        public async Task<IdentityUser?> GetUserByIdAsync(IdentityUserIdRef id)
        {
            return await UserSet.FindAsync(id);
        }
        
        
        public async Task<IdentityUser?> GetUserByEmailAsync(string email)
        {
            return await UserSet.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
        
        
        public async Task<IdentityUser?> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            return await UserSet.Where( x => x.PhoneNumber == phoneNumber).FirstOrDefaultAsync(); 
        }

    #endregion


    #region Get users

        public ICollection<IdentityUser> GetUsers()
        {
            return  UserSet.ToList();
        }

        public async Task<ICollection<IdentityUser>> GetUsersAsync()
        {
            return await UserSet.ToListAsync();
        }
    #endregion


    #region Update user

        public void UpdateUser(IdentityUser user)
        {
            UserSet.Update(user);
        }
        // @todo make this async
        public Task UpdateUserAsync(IdentityUser user)
        {
           UserSet.Update(user);

           return Task.CompletedTask;
        }

    #endregion


    #region Delete user

        public void DeleteUser(IdentityUser user)
        {
            UserSet.Remove(user);
        }
        
        public async Task DeleteUserAsync(IdentityUser user, CancellationToken? cancellationToken)
        {
            await UserSet.Where(
                x => x.Id == user.Id
            ).ExecuteDeleteAsync(
                cancellationToken 
                ?? CancellationToken.None);
        }
    #endregion

    
    #region IDisposable

        public void Dispose()
        {
            dbContext.Dispose();
        }
    #endregion


}
