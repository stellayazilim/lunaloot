using ErrorOr;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.ListPerms;

public class ListPermsQueryHandler(
    IPermissionProvider permissionProvider
    ): IRequestHandler<ListPermsQuery, ErrorOr<ListPermsQueryResult>>
{
    public async Task<ErrorOr<ListPermsQueryResult>> Handle(ListPermsQuery request, CancellationToken cancellationToken)
    {

        var permissions = permissionProvider.GetPermissions();

        await Task.CompletedTask;
        return new ListPermsQueryResult(
            Perms: permissions,
            Count: permissions.Count

        );
    }
}