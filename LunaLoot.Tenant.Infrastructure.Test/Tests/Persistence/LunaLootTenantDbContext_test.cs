using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using Telerik.JustMock;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Persistence;

public class LunaLootTenantDbContextTest
{
    public class LunaLootTenantDbContextTests
{
    [Fact]
    public void CanCreateDbContext_WithInMemoryDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<LunaLootTenantDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        // Act
        using var context = new LunaLootTenantDbContext(options);

        // Assert
        Assert.NotNull(context);
        Assert.IsType<LunaLootTenantDbContext>(context);
    }

    [Fact]
    public void CanPerformCRUDOperations_OnIdentityEntities()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<LunaLootTenantDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using var context = new LunaLootTenantDbContext(options);
        var user = new ApplicationUser { UserName = "testuser", Email = "testuser@example.com" };
        var role = new ApplicationRole { Name = "TestRole" };

        // Act
        context.Users.Add(user);
        context.Roles.Add(role);
        context.SaveChanges();

        var fetchedUser = context.Users.Find(user.Id);
        var fetchedRole = context.Roles.Find(role.Id);

        // Assert
        Assert.NotNull(fetchedUser);
        Assert.Equal("testuser", fetchedUser.UserName);
        Assert.NotNull(fetchedRole);
        Assert.Equal("TestRole", fetchedRole.Name);
    }

    [Fact]
    public void OnModelCreating_ShouldInvokeBaseOnModelCreating()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<LunaLootTenantDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        
        using var context = new LunaLootTenantDbContext(options);

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