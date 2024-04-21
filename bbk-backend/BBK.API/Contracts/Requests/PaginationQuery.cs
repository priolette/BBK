namespace BBK.API.Contracts.Requests;

public record PaginationQuery
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}
