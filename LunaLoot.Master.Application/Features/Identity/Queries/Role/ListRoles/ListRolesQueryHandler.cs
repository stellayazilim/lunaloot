using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.Role.ListRoles;

public class ListRolesQueryHandler(
    IUnitOfWork unitOfWork
    ): IRequestHandler<ListRolesQuery, ErrorOr<ListRolesQueryResult>>
{
    public async Task<ErrorOr<ListRolesQueryResult>> Handle(ListRolesQuery request, CancellationToken cancellationToken)
    {

        var rolesResult = await unitOfWork.RoleRepository.GetAllAsync(cancellationToken);

        if (rolesResult.IsError) return rolesResult.Errors;

        return new ListRolesQueryResult(rolesResult.Value);
    }
}