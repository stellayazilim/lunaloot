using FluentAssertions;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using LunaLoot.Tenant.Infrastructure.Test.__mocks__;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Identity.Tests.Services;

public class ApplicationUserManagerTest
{
    [Fact]
    public void Test_ApplicationUserManger()
    {
        
        // arrange & act
        var manager = new ApplicationUserManager(
            Mocks.MockUserStore(),
            Mocks.MockIdentityOptions(),
            Mocks.MockPasswordHasher(),
            Mocks.MockUserValidators(),
            Mocks.MockPasswordValidators(),
            Mocks.MockKeyNormalizer(),
            Mocks.MockErrorDescriber(),
            Mocks.MockServiceProvider(),
            Mocks.MockApplicationUserManagerLogger()
            );
        
        // assert

        manager.Should().NotBeNull();
        
    }
}