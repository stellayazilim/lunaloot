using System.Security.Cryptography;
using ErrorOr;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Identity;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.ListRoles;

public class ListRolesQueryHandler
    
    (IIdentityService identityService)
    : IRequestHandler<ListRolesQuery, ErrorOr<ListRolesQueryResult>>
{
    public async Task<ErrorOr<ListRolesQueryResult>> Handle(ListRolesQuery request, CancellationToken cancellationToken)
    {
        List<IdentityRole> roles = await identityService.RoleManager.ListRolesAsync(cancellationToken);

        return new ListRolesQueryResult(
            Roles: roles
         );
    }
}