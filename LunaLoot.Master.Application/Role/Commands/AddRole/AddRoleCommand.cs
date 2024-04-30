using MediatR;
using ErrorOr;
using LunaLoot.Master.Domain.Identity.Enums;

namespace LunaLoot.Master.Application.Role.Commands.AddRole;

public record AddRoleCommand(
    string Name,
    byte Weight,
    List<Permissions> Perms
    ): IRequest<ErrorOr<AddRoleCommandResult>>;