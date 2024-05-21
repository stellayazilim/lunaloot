using System.Security.Claims;
using FluentAssertions;
using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using LunaLoot.Tenant.Infrastructure.Test.__mocks__;
using Telerik.JustMock;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Identity.Tests.Services;

public class ApplicationUserClaimPrincipalFactoryTest
{
    [Fact]
    public async Task Test_ApplicationUserClaimPrincipalFactory()
    {
        // arrange
        var factory = new ApplicationUserClaimPrincipalFactory(
                Mocks.MockUserManager(),
                Mocks.MockIdentityOptions()
            );
        
        // act 
        var act = await factory.CreateAsync(
            Mock.Create<ApplicationUser>()
        );

        // assert

        act.Should().BeOfType<ClaimsPrincipal>();
    }
}