using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Common.Model;
using HomeHub.Application.Features.Users.GetCurrentUserDetails;
using HomeHub.Application.Features.Users.GetCurrentUserInfo;
using HomeHub.Application.Features.Users.GetUsers;
using HomeHub.Domain.Enums.Users;
using HomeHub.Infrastructure.Queries.QueryBuilder;

namespace HomeHub.Infrastructure.Queries;

public class UserQuery : IUserQuery
{
    private readonly SqlSelectQueryBuilder _sqlSelectQueryBuilder;

    public UserQuery(SqlSelectQueryBuilder sqlSelectQueryBuilder)
    {
        _sqlSelectQueryBuilder = sqlSelectQueryBuilder;
    }

    public async Task<UserInfoDTO> GetUserInfo(string userId)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<UserInfoDTO>()
            .From("[dbo].[User]")
            .Where("Id = @Id", new { Id = userId })
            .Build()
            .ExecuteSingleOrDefault<UserInfoDTO>();
    }

    public async Task<UserRoleEnum> GetRole(string userId)
    {
        return await _sqlSelectQueryBuilder.Select("RoleId")
            .From("[dbo].[User]")
            .Where("Id = @Id", new { Id = userId })
            .Build()
            .ExecuteSingle<UserRoleEnum>();
    }

    public async Task<PageDTO<UserDTO>> GetUsers(PaginationCriteria criteria, CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<UserDTO>()
            .From("[dbo].[VW_Users]")
            .OrderBy(criteria.OrderBy)
            .BuildPagedQuery(criteria)
            .ExecuteToPage<UserDTO>();
    }

    public async Task<UserDetailsDTO> GetUserDetails(string userId)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<UserDetailsDTO>()
            .From("[dbo].[VW_Users]")
            .Where("Id = @Id", new { Id = userId })
            .Build()
            .ExecuteSingle<UserDetailsDTO>();
    }
}
