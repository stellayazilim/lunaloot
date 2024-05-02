using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Common.Errors.Auth;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.AddRoleToUser;

public class AddRoleToUserCommandHandler
    (
        IIdentityService identityService
        ): IRequestHandler<AddRoleToUserCommand, ErrorOr<EmptyResult>>
{
    public async Task<ErrorOr<EmptyResult>> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await identityService.UserManager.GetUserByIdAsync(request.UserId);

        if (user is null) return Errors.Auth.UserDoesNotExistError();

        await identityService.RoleManager.AddRoleToUserAsync(
            user,
            request.RoleId
        );

        return new EmptyResult();
    }
}