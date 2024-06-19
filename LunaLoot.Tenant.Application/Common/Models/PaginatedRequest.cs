using ErrorOr;
using MediatR;

namespace LunaLoot.Tenant.Application.Common.Models;

public record PaginatedRequest<TRequest>(
    int Size,
    int Page) : IRequest<ErrorOr<PaginatedResult<TRequest>>>;


 