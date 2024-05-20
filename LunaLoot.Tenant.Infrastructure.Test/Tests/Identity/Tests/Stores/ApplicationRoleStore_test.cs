using LunaLoot.Tenant.Infrastructure.Identity.Stores;
using LunaLoot.Tenant.Infrastructure.Test.__mocks__;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Identity.Tests.Stores;

public class ApplicationRoleStoreTest
{
    [Fact]
    public void Test_ApplicationRoleStore()
    {
        // act
        var store = new ApplicationRoleStore(
            Mocks.MockLunaLootTenantDbContext(), 
            Mocks.MockErrorDescriber());
        
        // assert
        Assert.NotNull(store);
    }
}