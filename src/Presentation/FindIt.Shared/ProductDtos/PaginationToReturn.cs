namespace FindIt.Shared.ProductDtos;
public record PaginationToReturn<T>(
    int PageIndex,
    int PageSize,
    int Count,
    IReadOnlyList<T> Data
);