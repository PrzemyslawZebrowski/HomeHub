using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Services;

namespace HomeHub.Application.Features.Users.GetCurrentUserDetails;

public class GetCurrentUserDetailsUseCase : IQueryHandler<GetCurrentUserDetailsQuery, UserDetailsDTO>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserQuery _userQuery;

    public GetCurrentUserDetailsUseCase(ICurrentUserService currentUserService, IUserQuery userQuery)
    {
        _currentUserService = currentUserService;
        _userQuery = userQuery;
    }

    public async Task<UserDetailsDTO> Handle(GetCurrentUserDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _userQuery.GetUserDetails(_currentUserService.UserId);
    }
}