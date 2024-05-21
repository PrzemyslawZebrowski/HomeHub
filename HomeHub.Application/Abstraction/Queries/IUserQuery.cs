using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Common.Model;
using HomeHub.Application.Features.Users.GetCurrentUserDetails;
using HomeHub.Application.Features.Users.GetCurrentUserInfo;
using HomeHub.Application.Features.Users.GetUsers;
using HomeHub.Domain.Enums.Users;

namespace HomeHub.Application.Abstraction.Queries;

public interface IUserQuery
{
    Task<UserInfoDTO> GetUserInfo(string userId);

    Task<UserRoleEnum> GetRole(string userId);

    Task<PageDTO<UserDTO>> GetUsers(PaginationCriteria criteria, CancellationToken cancellationToken);
    Task<UserDetailsDTO> GetUserDetails(string userId);
}