using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Common.Model;

namespace HomeHub.Application.Features.Users.GetUsers;

public record GetUsersQuery : PaginationCriteria, IQuery<PageDTO<UserDTO>>;