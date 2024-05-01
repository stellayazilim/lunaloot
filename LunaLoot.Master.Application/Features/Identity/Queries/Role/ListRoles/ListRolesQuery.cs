using ErrorOr;
using LunaLoot.Master.Domain.Identity;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.Role.ListRoles;

public record ListRolesQuery(): IRequest<ErrorOr<ListRolesQueryResult>>;


public record ListRolesQueryResult(
    List<IdentityRole> Roles
    );