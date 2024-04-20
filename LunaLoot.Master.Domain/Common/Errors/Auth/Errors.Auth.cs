using ErrorOr;

namespace LunaLoot.Master.Domain.Common.Errors.Auth;

public static partial class Errors
{
    public static class Auth
    {
        public static Error DuplicateEmailError(string email)
            => Error.Conflict(code: "Auth.DuplicateEmail", description: $"{email} already exists");
        public static Error UserDoesNotExistError()
            => Error.NotFound(code: "Auth.UserDoesNotExist", description: "User does not exist");

        public static Error InvalidCredentials()
            => Error.Validation(code: "Auth.InvalidCredentials", description: "Provided credentials are invalid");
    }
}