using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.DeleteRole;

public record DeleteRoleCommand(
    IdentityRoleId Id
    ): IRequest<ErrorOr<EmptyResult>>;
    
    
    