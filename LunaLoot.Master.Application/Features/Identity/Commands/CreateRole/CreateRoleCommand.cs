using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Domain.Identity.Enums;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.CreateRole;

public record CreateRoleCommand(
    string Name,
    string Description,
    UInt16 Weight,
    Permissions[] Permissions
    ): IRequest<ErrorOr<EmptyResult>>;



    
    
    
    