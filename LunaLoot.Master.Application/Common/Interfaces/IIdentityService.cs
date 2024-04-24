using Microsoft.AspNetCore.Mvc;
using ErrorOr;
namespace LunaLoot.Master.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<ErrorOr<EmptyResult>> CreateUserAsync(string userName, string password);

    Task<ErrorOr<EmptyResult>> DeleteUserAsync(string userId);
}