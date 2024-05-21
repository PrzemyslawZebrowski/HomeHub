using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Users.GetCurrentUserDetails;

namespace HomeHub.Application.Features.Users.GetUserDetails;

public class GetUserDetailsUseCase : IQueryHandler<GetUserDetailsQuery, UserDetailsDTO>
{
    private readonly IUserQuery _userQuery;

    public GetUserDetailsUseCase(IUserQuery userQuery)
    {
        _userQuery = userQuery;
    }

    public async Task<UserDetailsDTO> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _userQuery.GetUserDetails(request.UserId);
    }
}