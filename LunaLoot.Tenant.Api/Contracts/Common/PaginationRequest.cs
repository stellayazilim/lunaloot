namespace LunaLoot.Tenant.Api.Contracts.Common;

public record PaginationRequest<TCommand>
(int Size, int Page)
{
    public int Size { get; set; } = Size;
    public int Page { get; set; } = Page;
}