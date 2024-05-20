using FluentAssertions;
using LunaLoot.Tenant.Infrastructure.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using Telerik.JustMock;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Identity.Tests.Services;

public class ApplicationUserClaimPrincipalFactoryTest
{
    [Fact]
    public async Task Test_ApplicationUserClaimPrincipalFactory()
    {
        // arrange
        var factory = new ApplicationUserClaimPrincipalFactory();
        
        // act & assert
        Action act = () => factory.CreateAsync(
            Mock.Create<ApplicationUser>()
        );

        act.Should().Throw<NotImplementedException>();
    }
}