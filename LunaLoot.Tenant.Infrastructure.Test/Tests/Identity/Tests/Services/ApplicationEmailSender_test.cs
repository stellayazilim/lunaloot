using FluentAssertions;
using LunaLoot.Tenant.Domain.Identity.Entities;
using LunaLoot.Tenant.Infrastructure.Identity.Services;
using Telerik.JustMock;

namespace LunaLoot.Tenant.Infrastructure.Test.Tests.Identity.Tests.Services;

public class ApplicationEmailSenderTest
{


    [Fact]
    public void TestSendConfirmationLinkAsync()
    {
        // arrange
        var emailSender = new ApplicationEmailSender();
        // act
        var result = emailSender.SendConfirmationLinkAsync(Arg.IsAny<ApplicationUser>(), Arg.AnyString, Arg.AnyString);
        // assert
        result.Should().Be(Task.CompletedTask);
    }


    [Fact]
    public void TestSendPasswordResetLinkAsync()
    {
        // arrange
        var emailSender = new ApplicationEmailSender();
        
        // act
        var result = emailSender.SendPasswordResetLinkAsync(Arg.IsAny<ApplicationUser>(), Arg.AnyString, Arg.AnyString);
        // assert
        result.Should().Be(Task.CompletedTask);
        
    }
    
    
    [Fact]
    public void TestSendPasswordResetCodeAsync()
    {
        // arrange
        var emailSender = new ApplicationEmailSender();
        // act
        var result = emailSender.SendPasswordResetCodeAsync(Arg.IsAny<ApplicationUser>(), Arg.AnyString, Arg.AnyString);
        // assert
        result.Should().Be(Task.CompletedTask);
        
    }
}