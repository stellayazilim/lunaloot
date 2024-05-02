using ErrorOr;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.Role.ListRoles;

public class ListRolesQueryHandler(
    IIdentityService identityService
    ): IRequestHandler<ListRolesQuery, ErrorOr<ListRolesQueryResult>>
{
    public async Task<ErrorOr<ListRolesQueryResult>> Handle(ListRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await identityService.RoleManager.ListRolesAsync(cancellationToken);
        return new ListRolesQueryResult(
            Roles: roles
        );
    }
}