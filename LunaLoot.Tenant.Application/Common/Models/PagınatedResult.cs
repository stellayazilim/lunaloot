namespace LunaLoot.Tenant.Application.Common.Models;

public record PaginatedResult<TResource>(
    List<TResource> Data,
    int PageSize,
    int TotalPage,
    int CurrentPage)
{
    public List<TResource> Data { get; set; } = Data;
    public int PageSize { get; } = PageSize;
    public int TotalPage { get;  } = TotalPage;
    public int CurrentPage { get; } = CurrentPage;
 
};