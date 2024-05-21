using System;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Domain.Auth;
using HomeHub.Domain.Enums.Common;
using HomeHub.Domain.Enums.Users;
using Microsoft.AspNetCore.Http;

namespace HomeHub.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IUserQuery _userQuery;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserQuery userQuery)
    {
        _userQuery = userQuery;
        UserId = httpContextAccessor.HttpContext?.User?.FindFirst(Claims.NameIdentifier)?.Value;
        Email = httpContextAccessor.HttpContext?.User?.FindFirst(Claims.Email)?.Value;
        Currency = Enum.TryParse<CurrencyEnum>(httpContextAccessor.HttpContext?.Request.Headers["currency"],
            out var currency)
            ? currency
            : CurrencyEnum.PLN;
    }

    public string UserId { get; }
    public string Email { get; }
    public CurrencyEnum Currency { get; }

    public async Task<UserRoleEnum> GetRole()
    {
        return await _userQuery.GetRole(UserId);
    }
}