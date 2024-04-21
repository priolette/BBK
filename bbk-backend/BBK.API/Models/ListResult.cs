namespace BBK.API.Models;

// NOTE: BBK.API.Models namespace is used for domain models and DTOs
// not to be confused with BBK.API.Data.Models namespace which is used for database models
public class ListResult<T>
{
    public required List<T> Data { get; set; }
    public required int Total { get; set; }
    public int Size => Data.Count;
}
