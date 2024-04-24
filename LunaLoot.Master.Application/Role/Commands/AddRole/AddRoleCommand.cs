using MediatR;
using ErrorOr;
namespace LunaLoot.Master.Application.Role.Commands.AddRole;

public record AddRoleCommand(
    string Name,
    byte Weight,
    List<string> Perms
    ): IRequest<ErrorOr<AddRoleCommandResult>>;