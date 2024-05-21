using System.Collections.Generic;

namespace HomeHub.Application.Common.Model;

public record PageDTO<T>(List<T> Items, int PageSize, int PageNumber, long TotalCount);