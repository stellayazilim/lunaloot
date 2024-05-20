using LunaLoot.Tenant.Infrastructure.Identity.Stores;
using LunaLoot.Tenant.Infrastructure.Test.__mocks__;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Identity.Tests.Stores;

public class ApplicationUserStoreTest
{
    [Fact]
    public void Test_ApplicationUserStore()
    {
        // arrange
        var store = new ApplicationUserStore(
            Mocks.MockLunaLootTenantDbContext(),
            Mocks.MockErrorDescriber());
        
        // assert
        Assert.NotNull(store);
    }
}