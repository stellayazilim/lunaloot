using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using LunaLoot.Master.Domain.Identity;
using MediatR;

namespace LunaLoot.Master.Application.Role.Commands.AddRole;

public class AddRoleCommandHandler(
    IUnitOfWork unitOfWork
    ):IRequestHandler<AddRoleCommand, ErrorOr<AddRoleCommandResult>>
{
    public async Task<ErrorOr<AddRoleCommandResult>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var role = IdentityRole.CreateNew(
                request.Name,
                null,
                request.Weight,
                request.Perms,
                new ()
            
            );
        // try
        // {
        //     await unitOfWork.IdentityService.AddAsync(role);
        //
        //     return new AddRoleCommandResult();
        // }
        // catch (Exception e)
        // {
        //     return Error.Failure();
        // }

        return new AddRoleCommandResult();
    }
}