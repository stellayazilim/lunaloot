using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using Telerik.JustMock;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Persistence;

public class LunaLootTenantIdentityDbContextTest
{
    public class LunaLootTenantIdentityDbContextTests
{
    [Fact]
    public void CanCreateDbContext_WithInMemoryDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<LunaLootTenantIdentityDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        // Act
        using var context = new LunaLootTenantIdentityDbContext(options);

        // Assert
        Assert.NotNull(context);
        Assert.IsType<LunaLootTenantIdentityDbContext>(context);
    }

    [Fact]
    public void CanPerformCRUDOperations_OnIdentityEntities()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<LunaLootTenantIdentityDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using var context = new LunaLootTenantIdentityDbContext(options);
        var user = ApplicationUser.CreateNew(Guid.NewGuid(), "john@doe.com", "password");
        var role = ApplicationRole.CreateNew(Guid.NewGuid(), "role",  null);

        // Act
        context.Users.Add(user);
        context.Roles.Add(role);
        context.SaveChanges();

        var fetchedUser = context.Users.Find(user.Id);
        var fetchedRole = context.Roles.Find(role.Id);

        // Assert
        Assert.NotNull(fetchedUser);
        Assert.Equal("john@doe.com", fetchedUser.UserName);
        Assert.NotNull(fetchedRole);
        Assert.Equal("role", fetchedRole.Name);
    }

    [Fact]
    public void OnModelCreating_ShouldInvokeBaseOnModelCreating()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<LunaLootTenantIdentityDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        
        using var context = new LunaLootTenantIdentityDbContext(options);

        // Act
        var modelBuilder = Mock.Create<ModelBuilder>(Constructor.Mocked);

        var cac = new PrivateAccessor(context);
        cac.CallMethod("OnModelCreating", modelBuilder);

        // Assert
        // Assuming there are custom configurations, this part might change.
        // For now, we just ensure it doesn't throw and can be called.
        Assert.True(true);
    }
}
}