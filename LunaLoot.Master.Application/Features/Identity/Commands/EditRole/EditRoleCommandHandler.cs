using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Application.Common.Services;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.EditRole;

public class EditRoleCommandHandler(
    IIdentityService identityService,
    IDateTimeProvider dateTimeProvider
    ): IRequestHandler<EditRoleCommand, ErrorOr<EmptyResult>>
{
    public async Task<ErrorOr<EmptyResult>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await identityService.RoleManager.GetRoleByIdAsync(request.RoleId, cancellationToken);

        if (role is null) return new EmptyResult();
        role.Name = request.Name;
        role.Description = request.Description;
        role.Weight = request.Weight;
        role.UpdatedAt = dateTimeProvider.UtcNow;

        await identityService.RoleManager.UpdateRoleAsync(role, cancellationToken);

        return new EmptyResult();
    }
}