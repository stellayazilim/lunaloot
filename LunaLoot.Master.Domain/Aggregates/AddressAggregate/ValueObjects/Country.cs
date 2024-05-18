using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Aggregates.AddressAggregate.ValueObjects;

public class Country: ValueObject
{
    public  string Name{ get; init; }
    
    public string DisplayName { get; init; }
    
    public string? AsciiCode { get; init; }
    
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


