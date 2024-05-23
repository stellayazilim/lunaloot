using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Telerik.JustMock;

namespace LunaLoot.Tenant.Infrastructure.Test.__mocks__;

public static partial class Mocks
{
    public static LunaLootTenantIdentityDbContext MockLunaLootTenantDbContext() =>
        Mock.Create<LunaLootTenantIdentityDbContext>();
    public static IRoleStore<ApplicationRole> MockRoleStore() => 
        Mock.Create<IRoleStore<ApplicationRole>>();

    public static IEnumerable<IRoleValidator<ApplicationRole>> MockRoleValidator() =>
        Mock.Create<IEnumerable<IRoleValidator<ApplicationRole>>>();

    public static ILookupNormalizer MockKeyNormalizer() =>
        Mock.Create<ILookupNormalizer>();

    public static IdentityErrorDescriber MockErrorDescriber() =>
        Mock.Create<IdentityErrorDescriber>();

    public static ILogger<RoleManager<ApplicationRole>> MockRoleManagerLogger() =>
        Mock.Create<ILogger<RoleManager<ApplicationRole>>>();
    
    public static IServiceCollection MockServiceCollection() =>
        Mock.Create<IServiceCollection>();
    
    public static IdentityBuilder MockIdentityBuilder() =>
        Mock.Create<IdentityBuilder>();

    public static IOptions<IdentityOptions> MockIdentityOptions() =>
        Mock.Create<IOptions<IdentityOptions>>();

    public static IPasswordHasher<ApplicationUser> MockPasswordHasher() =>
        Mock.Create<IPasswordHasher<ApplicationUser>>();

    public static IEnumerable<IUserValidator<ApplicationUser>> 
        MockUserValidators() =>
            Mock.Create<IEnumerable<IUserValidator<ApplicationUser>>>();

    public static IEnumerable<IPasswordValidator<ApplicationUser>>
        MockPasswordValidators() =>
        Mock.Create<IEnumerable<IPasswordValidator<ApplicationUser>>>();

    public static  ILogger<UserManager<ApplicationUser>> MockApplicationUserManagerLogger()
        => Mock.Create<ILogger<UserManager<ApplicationUser>>>();

    public static IUserStore<ApplicationUser> MockUserStore()
        => Mock.Create<IUserStore<ApplicationUser>>();

    public static IServiceProvider MockServiceProvider() =>
        Mock.Create<IServiceProvider>();

    public static IConfigurationManager MockConfigurationManager() =>
        Mock.Create<IConfigurationManager>();

    public static ApplicationUserManager MockUserManager() =>
        Mock.Create<ApplicationUserManager>();

    public static WebApplication MockWebApplication() =>
        Mock.Create<WebApplication>();
}