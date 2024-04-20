namespace BBK.API.Contracts.Responses;

public record PagedResponse<T>
{
    public IEnumerable<T> Data { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int? PreviousPageNumber { get; set; }
    public int? NextPageNumber { get; set; }

    public PagedResponse(IEnumerable<T> data)
    {
        Data = data;
        PageNumber = 1;
        PageSize = data.Count();
    }

    public PagedResponse(IEnumerable<T> data, int pageNumber, int pageSize)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public PagedResponse(IEnumerable<T> data, int pageNumber, int pageSize, int total)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = data.Count();
        PreviousPageNumber = pageNumber > 1 ? pageNumber - 1 : null;
        NextPageNumber = total > pageNumber * pageSize ? pageNumber + 1 : null;
    }
}
