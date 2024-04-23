using ErrorOr;

namespace LunaLoot.Master.Infrastructure.Common.Errors;

public static partial class Errors
{
    public static class OtpErrors
    {
        public static Error OtpStillValid => Error.Conflict(
                description: "Generated otp code still valid for the identified entity",
                code: "Otp.CodeStillValid"
            );
    }
}