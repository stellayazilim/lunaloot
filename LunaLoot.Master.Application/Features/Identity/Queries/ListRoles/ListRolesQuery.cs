using ErrorOr;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Enums;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.ListRoles;


public record ListRolesQuery: IRequest<ErrorOr<ListRolesQueryResult>>;
public record ListRolesQueryResult(
    List<IdentityRole> Roles
    );
    
    
    
