using LunaLoot.Tenant.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LunaLoot.Tenant.Infrastructure.Identity.Services;

public class ApplicationUserManater(
    IUserStore<ApplicationUser> store,
    IOptions<IdentityOptions> optionsAccessor,
    IPasswordHasher<ApplicationUser> passwordHasher,
    IEnumerable<IUserValidator<ApplicationUser>> userValidators,
    IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    IServiceProvider services,
    ILogger<UserManager<ApplicationUser>> logger)
    : UserManager<ApplicationUser>(store, optionsAccessor, passwordHasher, userValidators, passwordValidators,
        keyNormalizer, errors, services, logger);