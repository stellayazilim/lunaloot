﻿using LunaLoot.Tenant.Infrastructure.Identity;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using LunaLoot.Tenant.Infrastructure.Test.__mocks__;
using Microsoft.Extensions.Configuration;
using Telerik.JustMock;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests;

public class DependencyInjectionTest
{
    [Fact]
    public void TestDependencyInjection()
    {   
        // arrange
        var mockServiceCollection = Mocks.MockServiceCollection();
        var mockConfiguration = Mocks.MockConfigurationManager();
        Mock.Arrange(() => mockServiceCollection.AddIdentity(Mock.Create<IConfigurationManager>()));
        Mock.Arrange(() => mockServiceCollection.AddEfCorePersistence(mockConfiguration));
        // act
        var services = DependencyInjection.AddInfrastructure(
            mockServiceCollection,
            mockConfiguration
        );
        
        // assert
        Mock.Assert(() => mockServiceCollection.AddIdentity(mockConfiguration), Occurs.Once());
        Mock.Assert(() => mockServiceCollection.AddEfCorePersistence(mockConfiguration), Occurs.Once());
        
        
    }
}