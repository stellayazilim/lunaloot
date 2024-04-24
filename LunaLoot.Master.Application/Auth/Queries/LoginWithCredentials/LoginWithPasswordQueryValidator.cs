using FluentValidation;
using LunaLoot.Master.Application.Auth.Commands.Register;

namespace LunaLoot.Master.Application.Auth.Queries.LoginWithCredentials;

public class LoginWithCredentialsQueryValidator: AbstractValidator<LoginWithPasswordQuery>
{
    public LoginWithCredentialsQueryValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().NotNull();
    }
    
}