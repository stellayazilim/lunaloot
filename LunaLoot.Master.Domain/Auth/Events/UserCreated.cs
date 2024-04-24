using LunaLoot.Master.Domain.Common.Interfaces;
using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Auth.Events;

public record UserCreated(ApplicationUser User): IDomainEvent;