using System.Runtime.CompilerServices;
using LunaLoot.Tenant.Infrastructure.Identity;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using LunaLoot.Tenant.Infrastructure.Test.__mocks__;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Persistence;

public class PersistenceDependencyInjectionTest
{
    [Fact]
    public void AddEfCorePersistence_ShouldAddDbContextToServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection();
        var configurationMock = Mock.Create<IConfiguration>();
        var connectionString = "Host=my_host;Database=my_db;Username=my_user;Password=my_pw";
        
        Mock.Arrange(() => configurationMock.GetConnectionString("DefaultConnection")).Returns(connectionString);

        // Act
        services.AddEfCorePersistence(configurationMock);

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetService<LunaLootTenantIdentityDbContext>();
        
        Assert.NotNull(dbContext);
        Assert.IsType<LunaLootTenantIdentityDbContext>(dbContext);
    }

    [Fact]
    public void AddEfCorePersistence_ShouldThrowException_WhenConnectionStringIsNullOrEmpty()
    {
        // Arrange
        var services = new ServiceCollection();
        var configurationMock = Mock.Create<IConfiguration>();

        Mock.Arrange(() => configurationMock.GetConnectionString("DefaultConnection")).Returns(string.Empty);

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() =>
            services.AddEfCorePersistence(configurationMock)
        );

        Assert.Equal("Connection string can not be null or empty", exception.Message);
    }
}