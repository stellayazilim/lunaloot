using System.Windows.Input;
using ErrorOr;
using MediatR;

namespace LunaLoot.Master.Application.Features.Auth.Commands.LoginCommand;

public record LoginCommand(
    string Email,
    string Password
    ): IRequest<ErrorOr<LoginCommandResult>>;