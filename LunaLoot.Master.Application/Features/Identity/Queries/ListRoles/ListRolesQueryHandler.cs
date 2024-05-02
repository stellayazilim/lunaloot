using System.Security.Cryptography;
using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using LunaLoot.Master.Domain.Identity;
using MediatR;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace LunaLoot.Master.Application.Features.Identity.Queries.ListRoles;

public class ListRolesQueryHandler(
    IUnitOfWork unitOfWork
    )
    : IRequestHandler<ListRolesQuery, ErrorOr<ListRolesQueryResult>>
{
    public async Task<ErrorOr<ListRolesQueryResult>> Handle(ListRolesQuery request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.RoleRepository.GetAllAsync(cancellationToken);
        
        if (result.IsError) return result.Errors;

        return new ListRolesQueryResult(result.Value);

    }
}