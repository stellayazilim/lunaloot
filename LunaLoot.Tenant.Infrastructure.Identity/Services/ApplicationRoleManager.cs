using LunaLoot.Tenant.Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace LunaLoot.Tenant.Infrastructure.Identity.Services;

public class ApplicationRoleManager(
    IRoleStore<ApplicationRole> store,
    IEnumerable<IRoleValidator<ApplicationRole>> roleValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    ILogger<RoleManager<ApplicationRole>> logger)
    : RoleManager<ApplicationRole>(store, roleValidators, keyNormalizer, errors, logger);