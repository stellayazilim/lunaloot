using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Domain.Identity.Enums;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.EditRole;

public record EditRoleCommand(
    IdentityRoleId RoleId,
    string Name,
    string? Description,
    ushort Weight,
    Permissions Permissions
    ): IRequest<ErrorOr<EmptyResult>>;