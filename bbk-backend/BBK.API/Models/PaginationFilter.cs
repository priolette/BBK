namespace BBK.API.Models;

public record PaginationFilter
{
    public required int PageSize { get; init; }
    public required int PageNumber { get; init; }
}
