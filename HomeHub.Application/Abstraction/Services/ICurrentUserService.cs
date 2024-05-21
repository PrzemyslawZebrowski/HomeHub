using System.Threading.Tasks;
using HomeHub.Domain.Enums.Common;
using HomeHub.Domain.Enums.Users;

namespace HomeHub.Application.Abstraction.Services;

public interface ICurrentUserService
{
    string Email { get; }
    string UserId { get; }
    CurrencyEnum Currency { get; }

    Task<UserRoleEnum> GetRole();
}