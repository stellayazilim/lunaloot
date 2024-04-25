using ErrorOr;
using MediatR;

namespace LunaLoot.Master.Application.Features.Auth.Commands.LoginCommand;

public class LoginCommandHandler: IRequestHandler<LoginCommand, ErrorOr<LoginCommandResult>>
{
    public async Task<ErrorOr<LoginCommandResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {

        await Task.CompletedTask;
        return new LoginCommandResult(Token: "token");
    }
}