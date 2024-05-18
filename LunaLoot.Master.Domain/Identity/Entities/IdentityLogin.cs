using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Domain.Identity.Entities;

public class IdentityLogin: Entity<IdentityLoginId>
{
    
    private IdentityLogin() {}

    private IdentityLogin(
        IdentityLoginId id,
        string refreshToken,
        DateTime validUntil,
        bool isConsumed,
        IdentityUserId userIdRef,
        IdentityUser user
    ) : base(id)
    {
        RefreshToken = refreshToken;
        ValidUntil = validUntil;
        IsConsumed = isConsumed;
        UserId = userIdRef;
        User = user;
    }
    public string RefreshToken { get; set; }
    public DateTime ValidUntil { get; set; }
    public bool IsConsumed { get; set; }
    public IdentityUserId UserId { get; set; }
    public IdentityUser User { get; set; }
    public static IdentityLogin CreateNew(
        string refreshToken,
        DateTime validUntil,
        IdentityUserId userId,
        IdentityUser user
    ) => new(IdentityLoginId.CreateNew(), refreshToken, validUntil, false, userId, user);

    public static IdentityLogin Parse(
        IdentityLoginId id,
        string refreshToken,
        DateTime validUntil,
        bool isConsumed,
        IdentityUserId userId,
        IdentityUser user
    ) => new(id, refreshToken, validUntil, isConsumed, userId, user);
}