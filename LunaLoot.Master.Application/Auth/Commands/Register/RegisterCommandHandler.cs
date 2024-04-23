using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Common.Errors.Auth;
using MediatR;

namespace LunaLoot.Master.Application.Auth.Commands.Register;

public class RegisterCommandHandler(
    IUnitOfWork unitOfWork): 
    IRequestHandler<RegisterCommand, ErrorOr<RegisterCommandResult>>

{


    public async Task<ErrorOr<RegisterCommandResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {

        if (await unitOfWork.UserRepository.GetByEmailAsync(command.Email) is not null)
            return Errors.Auth.DuplicateEmailError(command.Email);
        
        // if not exists then generate user with unique id
        
        var user = ApplicationUser.CreateNew(
            command.FirstName,
            command.LastName,
            command.Email,
            command.PhoneNumber,
            command.Password,
            null,
            new(),
            new());
        
        
        await unitOfWork.UserRepository.AddAsync(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new RegisterCommandResult();
    }
}