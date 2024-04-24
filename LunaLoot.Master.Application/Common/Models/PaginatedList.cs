using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LunaLoot.Master.Application.Common.Models;

public class PaginatedList<TItem>
{
    public IReadOnlyCollection<TItem> Items { get; }
    public UInt32 PageNumber { get; }
    public UInt32 TotalPages { get; }
    public ulong TotalCount { get; }


    public PaginatedList(IReadOnlyCollection<TItem> items, ulong count, UInt32 pageNumber, byte pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (UInt32)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    public static  PaginatedList<TItem> Create(IList<TItem> source, UInt32 pageNumber,
        byte pageSize)
    {
        
        var items = source.Skip((int)(pageNumber - 1) * source.Count()).Take(source.Count).ToList();

        return new PaginatedList<TItem>(items, (ulong)source.Count(), pageNumber, pageSize);
    }
}