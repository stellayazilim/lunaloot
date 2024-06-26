﻿using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using LunaLoot.Tenant.Infrastructure.Identity.Stores;
using LunaLoot.Tenant.Infrastructure.Persistence.EFCore;
using LunaLoot.Tenant.Infrastructure.Test.__mocks__;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telerik.JustMock;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Identity.Tests;

public class DependencyInjectionTest
{
    [Fact]
    public void Test_AddIdentity()
    {   
        // Arrange
        var services = Mocks.MockServiceCollection();
        var mockIdentityBuilder = Mocks.MockIdentityBuilder();

        // Mock the return values of the chained methods
        Mock.Arrange(() => services.AddIdentityCore<ApplicationUser>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddRoles<ApplicationRole>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddRoleStore<ApplicationRoleStore>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddRoleValidator<RoleValidator<ApplicationRole>>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddRoleManager<ApplicationRoleManager>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddClaimsPrincipalFactory<ApplicationUserClaimPrincipalFactory>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddUserStore<ApplicationUserStore>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddUserValidator<UserValidator<ApplicationUser>>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddUserConfirmation<DefaultUserConfirmation<ApplicationUser>>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddUserManager<ApplicationUserManager>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddEntityFrameworkStores<LunaLootTenantIdentityDbContext>()).Returns(mockIdentityBuilder);
        Mock.Arrange(() => mockIdentityBuilder.AddDefaultTokenProviders()).Returns(mockIdentityBuilder);
        
        // act
        // ReSharper disable once InvokeAsExtensionMethod
        LunaLootTenantIdentityExtensions.AddIdentity(services, Mock.Create<IConfigurationManager>());
        
        // assert   
        Mock.Assert(() => services.AddIdentityCore<ApplicationUser>(), Occurs.Once());
        Mock.Assert(() => mockIdentityBuilder.AddRoles<ApplicationRole>(), Occurs.Once());
        Mock.Assert(() => mockIdentityBuilder.AddRoleStore<ApplicationRoleStore>(), Occurs.Once());
        Mock.Assert(() => mockIdentityBuilder.AddRoleValidator<RoleValidator<ApplicationRole>>(), Occurs.Once());
        Mock.Assert(() => mockIdentityBuilder.AddRoleManager<ApplicationRoleManager>(), Occurs.Once());
        Mock.Assert(() => mockIdentityBuilder.AddClaimsPrincipalFactory<ApplicationUserClaimPrincipalFactory>(), Occurs.Once());
        Mock.Assert(() => mockIdentityBuilder.AddUserStore<ApplicationUserStore>(), Occurs.Once());
        Mock.Assert(() => mockIdentityBuilder.AddUserValidator<UserValidator<ApplicationUser>>(), Occurs.Once());
        Mock.Assert(() => mockIdentityBuilder.AddUserConfirmation<DefaultUserConfirmation<ApplicationUser>>(), Occurs.Once());
        Mock.Assert(() => mockIdentityBuilder.AddUserManager<ApplicationUserManager>(), Occurs.Once());
        Mock.Assert(() => mockIdentityBuilder.AddEntityFrameworkStores<LunaLootTenantIdentityDbContext>(), Occurs.Once());
        // @todo   Mock.Assert(() => mockIdentityBuilder.AddDefaultTokenProviders(), Occurs.Once());

        Assert.True(Mock.IsProfilerEnabled);
    }


    [Fact]
    public void Test_AddIdentityEndpoints_ShouldRegister()
    {
        // arrange 
        var app = Mocks.MockWebApplication();
        Mock.Arrange(() => app.MapIdentityApi<ApplicationUser>()).Returns(Arg.IsAny<IEndpointConventionBuilder>());
        
        // act
        LunaLootTenantIdentityExtensions.AddIdentityEndpoints(app);
        
        // arrange
        Mock.Assert(() => app.MapIdentityApi<ApplicationUser>(), Occurs.Once());
    }
}