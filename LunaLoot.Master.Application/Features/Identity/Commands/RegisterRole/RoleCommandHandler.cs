using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Identity;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.RegisterRole;

public class RoleCommandHandler
    (
        IIdentityService identityService): IRequestHandler<RegisterRoleCommand, ErrorOr<EmptyResult>>
{
    public async Task<ErrorOr<EmptyResult>> Handle(RegisterRoleCommand request, CancellationToken cancellationToken)
    {

        await identityService.RoleManager.CreateRoleAsync(IdentityRole.CreateNew(
            name: request.Name,
            description: request.Description,
            weight: request.Weight,
            permissions: request.Permissions.ToList(),
            users: new()
            ), cancellationToken);
        throw new NotImplementedException();
    }
}