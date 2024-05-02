using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Identity;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.CreateRole;

public class CreateRoleCommandHandler
    (
        IIdentityManager identityManager,
        IUnitOfWork unitOfWork): IRequestHandler<CreateRoleCommand, ErrorOr<EmptyResult>>
{
    public async Task<ErrorOr<EmptyResult>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        return await unitOfWork.RoleRepository.AddAsync(IdentityRole.CreateNew(
            name: request.Name,
            description: request.Description,
            weight: request.Weight,
            permissions: request.Permissions,
            users: new()
        ));

    }
}