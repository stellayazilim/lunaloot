using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Domain.Identity.Enums;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.ListRolesQuery;

public record ListRolesQuery(): IRequest<ErrorOr<PaginatedList<ListRolesQueryResult>>>;

public record ListRolesQueryResult(
    Guid Id,
    string Name,
    string Description,
    byte Weight,
    List<Permissions> Permissions);