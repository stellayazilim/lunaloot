using LunaLoot.Master.Application.Auth.Queries.Login;
using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Domain.Common.Errors.Auth;
using ErrorOr;
using FluentValidation;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using MediatR;


namespace LunaLoot.Master.Application.Auth.Queries.LoginWithCredentials;

public class LoginWithPasswordQueryHandler
(
    
  
    IAuthRepository authRepository, ITokenGenerator tokenGenerator): IRequestHandler<
    LoginWithCredentialsQuery, 
    ErrorOr<LoginWithPasswordQueryResult>>
{
    
    public async Task<ErrorOr<LoginWithPasswordQueryResult>> Handle(
        LoginWithCredentialsQuery withPasswordQuery,
        CancellationToken cancellationToken)
    {

        
        var user = await authRepository.GetUserByEmailAsync(withPasswordQuery.Email);
       
        //  validate if user exists
        if (user is null)
            return Errors.Auth.InvalidCredentials();
        
        // validate if password match
        if (user?.Password != withPasswordQuery.Password) 
            return Errors.Auth.InvalidCredentials();
        var token = tokenGenerator.GenerateToken(user);
        return new LoginWithPasswordQueryResult(user, token);
    }
}