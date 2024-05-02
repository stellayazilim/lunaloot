using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Common.Errors;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.AddRoleToUser;

public class AddRoleToUserCommandHandler
    (
        IIdentityManager identityManager,
        IUnitOfWork unitOfWork
        ): IRequestHandler<AddRoleToUserCommand, ErrorOr<EmptyResult>>
{
    public async Task<ErrorOr<EmptyResult>> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {

        var user = await unitOfWork.UserRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user.IsError) return user.Errors;

        var role = unitOfWork.RoleRepository.GetByIdAsync(request.RoleId, cancellationToken).Result;

        if (role.IsError) return role.Errors;

        return await identityManager.JoinUserToRoleAsync(user.Value, role.Value, cancellationToken);
    }
}