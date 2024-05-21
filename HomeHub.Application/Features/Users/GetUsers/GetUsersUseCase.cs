using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Common.Model;

namespace HomeHub.Application.Features.Users.GetUsers;

public class GetUsersUseCase : IQueryHandler<GetUsersQuery, PageDTO<UserDTO>>
{
    private readonly IUserQuery _userQuery;

    public GetUsersUseCase(IUserQuery userQuery)
    {
        _userQuery = userQuery;
    }

    public async Task<PageDTO<UserDTO>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        return await _userQuery.GetUsers(query, cancellationToken);
    }
}