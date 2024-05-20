using LunaLoot.Tenant.Infrastructure.Identity.Services;
using LunaLoot.Tenant.Infrastructure.Test.__mocks__;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Identity.Tests.Services;

public class ApplicationRoleManagerTest
{
    [Fact]
    public void TestApplicationRoleManager()
    {
        // arrange
        var manager = new ApplicationRoleManager(
            Mocks.MockRoleStore(),
            Mocks.MockRoleValidator(),
            Mocks.MockKeyNormalizer(),
            Mocks.MockErrorDescriber(),
            Mocks.MockRoleManagerLogger()
        );
        
        // assert
        Assert.NotNull(manager);
    }
}