using ErrorOr;
using LunaLoot.Master.Domain.Address.ValueObjects;
using MediatR;

namespace LunaLoot.Master.Application.Auth.Commands.Register;

/// <summary>
/// The register command
/// </summary>
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    RegisterCommandAddress Address): IRequest<ErrorOr<RegisterCommandResult>>;

/// <summary>
/// The register command address
/// </summary>
public record RegisterCommandAddress(
        string Country,
        string City,
        string Province,
        string Town,
        string Street,
        string PostCode,
        string Name,
        string Description
    );

