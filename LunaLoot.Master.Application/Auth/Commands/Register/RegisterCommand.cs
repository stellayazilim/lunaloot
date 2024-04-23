using ErrorOr;
using LunaLoot.Master.Domain.Address.ValueObjects;
using MediatR;

namespace LunaLoot.Master.Application.Auth.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    RegisterCommandAddress Address): IRequest<ErrorOr<RegisterCommandResult>>;

public record RegisterCommandAddress(
        RegisterCommandCountry Country,
        string City,
        string Province,
        string Town,
        string Street,
        string PostCode,
        string Name,
        string Description
    );

public record RegisterCommandCountry(
        string Name,
        string? IsoCode,
        string? AsciiCode
    );
    