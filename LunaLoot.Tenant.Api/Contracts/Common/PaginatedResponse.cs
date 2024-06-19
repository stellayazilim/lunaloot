using LunaLoot.Tenant.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace LunaLoot.Tenant.Api.Contracts.Common;

public record PaginatedResponse<TResource>
(
    List<TResource> Data,
    int Page,
    int TotalPage,
    int CurrentPage,
    bool HasNextPage,
    bool HasPreviousPage,
    string NextPage,
    string PreviousPage)
{
    public List<TResource> Data { get; set; } = Data;

    public int Page { get; set; } = Page;

    public int TotalPage { get; set; } = TotalPage;

    public int CurrentPage { get; set; } = CurrentPage;
 
    public bool HasNextPage { get; set; } = HasNextPage;

    public bool HasPreviousPage { get; set; } = HasPreviousPage;

    public string NextPage { get; set; } = NextPage;

    public string PreviousPage { get; set; } = PreviousPage;

}