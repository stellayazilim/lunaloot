using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Common.Errors.Auth;
using MediatR;

namespace LunaLoot.Master.Application.Auth.Commands.Register;

public class RegisterCommandHandler(
    IAuthRepository authRepository): 
    IRequestHandler<RegisterCommand, ErrorOr<RegisterCommandResult>>

{
    private readonly IAuthRepository _authRepository = authRepository;


    public async Task<ErrorOr<RegisterCommandResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {

        if (await _authRepository.GetUserByEmailAsync(email: command.Email) is not null)
            return Errors.Auth.DuplicateEmailError(command.Email);
        
        // if not exists then generate user with unique id

        var user = new ApplicationUser()
        {
            Id = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        await authRepository.CreateAsync(user);
        
        return new RegisterCommandResult();
    }
}