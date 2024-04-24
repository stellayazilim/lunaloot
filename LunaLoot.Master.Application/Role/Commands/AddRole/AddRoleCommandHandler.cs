using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Domain.Auth.Entities;
using MediatR;

namespace LunaLoot.Master.Application.Role.Commands.AddRole;

public class AddRoleCommandHandler(
    IUnitOfWork unitOfWork
    ):IRequestHandler<AddRoleCommand, ErrorOr<AddRoleCommandResult>>
{
    public async Task<ErrorOr<AddRoleCommandResult>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {

        var role = ApplicationRole.CreateNew(
                request.Name,
                request.Weight,
                request.Perms
            );
        try
        {
            await unitOfWork.RoleRepository.AddAsync(role);

            return new AddRoleCommandResult();
        }
        catch (Exception e)
        {
            return Error.Failure();
        }
    }
}