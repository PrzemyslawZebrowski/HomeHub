namespace HomeHub.Application.Common.Model;

public record PaginationCriteria(int PageSize = 10, int PageNumber = 1, string OrderBy = null);