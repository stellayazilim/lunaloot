using MediatR;
using ErrorOr;
namespace LunaLoot.Master.Application.Role.Commands.AddRole;

public record AddRoleCommand(): IRequest<ErrorOr<AddRoleCommandResult>>;