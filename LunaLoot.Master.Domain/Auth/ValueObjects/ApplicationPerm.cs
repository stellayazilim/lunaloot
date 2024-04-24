using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Auth.ValueObjects;

/// <summary>
/// The application role perm class
/// </summary>
/// <seealso cref="ValueObject"/>
public class ApplicationRolePerm: ValueObject
{

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRolePerm"/> class
    /// </summary>
    /// <param name="readType">The read type</param>
    /// <param name="perm">The perm</param>
    private ApplicationRolePerm(string readType, string perm)
    {
        ReadType = readType;
        Perm = perm;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRolePerm"/> class
    /// </summary>
    private ApplicationRolePerm() {}
    
    /// <summary>
    /// Gets or sets the value of the read type
    /// </summary>
    public string ReadType { get; private set; }
    
    /// <summary>
    /// Gets or sets the value of the perm
    /// </summary>
    public string Perm { get; private set; }
    /// <summary>
    /// Gets the equality components
    /// </summary>
    /// <returns>An enumerable of object</returns>
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return ReadType;
        yield return Perm;
    }

    /// <summary>
    /// Creates the new using the specified read type
    /// </summary>
    /// <param name="readType">The read type</param>
    /// <param name="perm">The perm</param>
    /// <returns>The application role perm</returns>
    public static ApplicationRolePerm CreateNew(
        string readType,
        string perm
        ) => new(readType, perm);
}