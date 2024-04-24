using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Domain.Address;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Common.Errors.Auth;
using MediatR;

namespace LunaLoot.Master.Application.Auth.Commands.Register;

/// <summary>
/// The register command handler class
/// </summary>
/// <seealso cref="IRequestHandler{RegisterCommand, ErrorOr{RegisterCommandResult}}"/>
public class RegisterCommandHandler(
    IUnitOfWork unitOfWork): 
    IRequestHandler<RegisterCommand, ErrorOr<RegisterCommandResult>>

{
    /// <summary>
    /// Handles the command
    /// </summary>
    /// <param name="command">The command</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A task containing an error or of register command result</returns>
    public async Task<ErrorOr<RegisterCommandResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {

        if (await unitOfWork.UserRepository.GetByEmailAsync(command.Email, cancellationToken) is not null)
            return Errors.Auth.DuplicateEmailError(command.Email);
        
        // if not exists then generate user with unique id

        RegisterCommandAddress addressCmd = command.Address;
        
        var address = Address.CreateNew(
                country: addressCmd.Country,
                city: addressCmd.City,
                province: addressCmd.Province,
                town: addressCmd.Town,
                street: addressCmd.Street,
                postCode: addressCmd.PostCode,
                name: addressCmd.Name,
                description: addressCmd.Description);
        
        var user = ApplicationUser.CreateNew(
            command.FirstName,
            command.LastName,
            command.Email,
            command.PhoneNumber,
            command.Password,
            null,
            new()
            {
                address.Id
            },
            new());


        await unitOfWork.AddressRepository.AddAsync(address, cancellationToken);
        await unitOfWork.UserRepository.AddAsync(user, cancellationToken);
        
        return new RegisterCommandResult();
    }
}