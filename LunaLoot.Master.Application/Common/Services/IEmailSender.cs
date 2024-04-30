using LunaLoot.Master.Domain.Identity;
using EmailSender = Microsoft.AspNetCore.Identity.UI.Services.IEmailSender;
namespace LunaLoot.Master.Application.Common.Services;


/// <summary>
/// The email sender interface
/// </summary>
/// <seealso cref="EmailSender"/>
public interface IEmailSender: EmailSender
{
    /// <summary>
    /// Sends the verification email using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    void SendVerificationEmail(IdentityUser user);
    /// <summary>
    /// Sends the verification email using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="cancellationToken">The cancellation token</param>
    Task SendVerificationEmailAsync(IdentityUser user, CancellationToken? cancellationToken = null);
}