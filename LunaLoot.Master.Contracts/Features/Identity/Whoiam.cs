using System.Text.Json.Serialization;


namespace LunaLoot.Master.Contracts.Features.Identity;

public class WhoiamResponse
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    [JsonPropertyName("roles")]
    public List<ListRoleItem?>? Roles { get; set; }

    [JsonPropertyName("isAuthenticated")]
    public bool? IsAuthenticated { get; set; }
    
    

}