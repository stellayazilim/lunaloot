using LunaLoot.Master.Application.Common.Services;

namespace LunaLoot.Master.Infrastructure.Services;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}