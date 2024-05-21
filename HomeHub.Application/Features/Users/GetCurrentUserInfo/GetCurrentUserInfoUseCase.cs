using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Services;

namespace HomeHub.Application.Features.Users.GetCurrentUserInfo;

public class GetCurrentUserInfoUseCase : IQueryHandler<GetCurrentUserInfoQuery, UserInfoDTO>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserQuery _userQuery;

    public GetCurrentUserInfoUseCase(ICurrentUserService currentUserService, IUserQuery userQuery)
    {
        _currentUserService = currentUserService;
        _userQuery = userQuery;
    }

    public async Task<UserInfoDTO> Handle(GetCurrentUserInfoQuery request, CancellationToken cancellationToken)
    {
        return await _userQuery.GetUserInfo(_currentUserService.UserId);
    }
}