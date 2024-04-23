using LunaLoot.Master.Application.Common.Interfaces;
using LunaLoot.Master.Domain.Common.Errors.Auth;
using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using MediatR;


namespace LunaLoot.Master.Application.Auth.Queries.LoginWithCredentials;

public class LoginWithPasswordQueryHandler
(
    IUnitOfWork unitOfWork, ITokenGenerator tokenGenerator): IRequestHandler<
    LoginWithCredentialsQuery, 
    ErrorOr<LoginWithPasswordQueryResult>>
{
    
    public async Task<ErrorOr<LoginWithPasswordQueryResult>> Handle(
        LoginWithCredentialsQuery withPasswordQuery,
        CancellationToken cancellationToken)
    {

        
        var user = await unitOfWork.UserRepository.GetByEmailAsync(withPasswordQuery.Email);
       
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