using FluentAssertions;
using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity.Enums;
using Telerik.JustMock;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Identity.Tests.Entities;

public class ApplicationRoleTest
{
    [Fact]
    public void TestApplicationRole()
    {
        // Arrange & act
        var role = ApplicationRole.CreateNew(Guid.NewGuid(), "role", null);
        var accessor = new PrivateAccessor(role);
        var perms = (List<ApplicationPermissions>)accessor.GetField("_permissions");
        // assert

        perms.Count.Should().Be(role.Permissions.Count);
        role.Permissions.Count.Should().Be(perms.Count);
    }
}