using FluentAssertions;
using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity.Enums;

namespace LunaLoot.Tenant.Domain.Test.Tests.Identity.Entities;

public class ApplicationRoleTest
{
    
    [Fact]
    public void Test_ApplicationRole_ShouldInstantied() {
        
        // arrange
        var name = "role";
        var id = Guid.NewGuid();
        var perms = new List<ApplicationPermissions>();
        // act
        var role = ApplicationRole.CreateNew(
            id, name, perms);
        // assert
        role.Permissions.Should().Equal(perms);
        role.Name.Should().Be(name);
        role.Id.Should().Be(id);
    }
}