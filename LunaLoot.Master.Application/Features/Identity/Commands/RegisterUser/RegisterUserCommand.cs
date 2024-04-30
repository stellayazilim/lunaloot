using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.RegisterUser;

public record RegisterUserCommand(
    string FullName,
    string Email,
    string PhoneNumber,
    string Password
    ): IRequest<ErrorOr<EmptyResult>>;