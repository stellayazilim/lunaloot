using FluentAssertions;
using LunaLoot.Tenant.Domain.Identity.Entities;

namespace LunaLoot.Tenant.Domain.Test.Tests.Identity.Entities;
public class ApplicationUserTest
{
    [Fact]
    public void Test_ApplicationUser_ShouldInstantiate()
    {
        // arrange
        var userId = Guid.NewGuid();
        var password = "password";
        var email = "john@doe.com";
        
        // act
        var user =ApplicationUser.CreateNew(
                userId,
                email,
                password
            );
        
        // assert

        user.Email.Should().Be(email);
        user.NormalizedEmail.Should().Be(email);
        user.UserName.Should().Be(email);
        user.Id.Should().Be(userId);
        user.PasswordHash.Should().Be(password);

    }
}