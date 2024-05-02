using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.AddRoleToUser;

public record AddRoleToUserCommand(
    IdentityUserId UserId,
    IdentityRoleId RoleId
    ): IRequest<ErrorOr<EmptyResult>>;