using ErrorOr;
using LunaLoot.Master.Application.Common.Models;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Application.Common.Services;
using LunaLoot.Master.Application.Features.Identity.Interfaces;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Commands.EditRole;

public class EditRoleCommandHandler(
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider
    ): IRequestHandler<EditRoleCommand, ErrorOr<EmptyResult>>
{
    public async Task<ErrorOr<EmptyResult>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.RoleRepository.GetByIdAsync(request.RoleId);

        if (result.IsError) return result.Errors;

        var role = result.Value;
        
        role.Name = request.Name;
        role.Description = request.Description;
        role.Weight = request.Weight;
        role.UpdatedAt = dateTimeProvider.UtcNow;
        return unitOfWork.RoleRepository.Update(role);
    }
}