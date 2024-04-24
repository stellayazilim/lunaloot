using LunaLoot.Master.Domain.Auth.Events;
using MediatR;

namespace LunaLoot.Master.Application.Auth.Events;

public class UserCreatedEventHandler: INotificationHandler<UserCreated>
{
    public Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        
        return Task.CompletedTask;
    }
}