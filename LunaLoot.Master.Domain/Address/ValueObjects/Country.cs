using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Address.ValueObjects;

public class Country: ValueObject
{
    /// <summary>
    /// Country name eg `United states`
    /// </summary>
    public  string Name { get; init; }
    
    /// <summary>
    /// User friendly country name,
    /// eg USA insted of United States of America
    /// </summary>
    public string DisplayName { get; init; }
    
    /// <summary>
    /// Country code eg `1`
    /// </summary>
    public string?  AsciiCode { get; init; }
    
    
    /// <summary>
    /// Country iso code, eg `US`
    /// </summary>
    public string? IsoCode { get; init; }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return AsciiCode ?? string.Empty;
        yield return IsoCode ?? string.Empty;
    }
    
    #region Constructors

    #pragma warning disable CS8618 
    private Country() {}
    #pragma warning restore CS8618
    
    private Country(
        string name
    )
    {
        Name = name;
    }
    private Country(
        string name,
        string isoCode
    )
    {
        Name = name;
        IsoCode = isoCode;
    }
        
    private Country(
        string name,
        string isoCode,
        string asciiCode
    )
    {
        Name = name;
        AsciiCode = asciiCode;
        IsoCode = isoCode;
    }
    #endregion
    

    #region StaticFactory #CreateNew
    /// <summary>
    /// creates new country instance with static
    /// static factory method. 
    /// </summary>
    /// <param name="name"> Country Name <see href=""/> </param>
    /// <param name="isoCode"> Country iso code </param>
    /// <param name="asciiCode"> country ascii code </param>
    /// <returns></returns>
    
        public static Country CreateNew(
            string name
        ) => new(name);


    public static Country CreateNew(
            string name,
            string isoCode
        ) => new(name, isoCode);
        
      
    public static Country CreateNew(
        string name,
        string isoCode,
        string asciiCode
    ) => new(name,asciiCode , asciiCode);    
    #endregion
}


