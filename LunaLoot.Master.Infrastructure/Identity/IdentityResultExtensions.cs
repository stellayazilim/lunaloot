using ErrorOr;
using Microsoft.AspNetCore.Identity;

namespace LunaLoot.Master.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static ErrorOr<IdentityResult> ToApplicationResult(this IdentityResult result)
    {
        return result;
    }
}