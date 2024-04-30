using ErrorOr;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Features.Identity.Interfaces;

namespace LunaLoot.Master.Infrastructure.Identity.Services;

public class IdentityService
    (
        IRoleManager roleManager,
        IUserManager userManager,
        IIdentityManager identityManager): IIdentityService
{


    public IRoleManager RoleManager => roleManager;
    public IUserManager UserManager => userManager;
    public IIdentityManager IdentityManager => identityManager;
}