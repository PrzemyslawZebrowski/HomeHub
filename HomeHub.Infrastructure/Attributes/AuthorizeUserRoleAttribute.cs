using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Domain.Enums.Users;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace HomeHub.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AuthorizeUserRoleAttribute : Attribute, IAsyncActionFilter
{
    private readonly IEnumerable<UserRoleEnum> _roles;

    public AuthorizeUserRoleAttribute(params UserRoleEnum[] roles)
    {
        _roles = roles ?? Enumerable.Empty<UserRoleEnum>();
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var currentUserService = context.HttpContext.RequestServices.GetService<ICurrentUserService>();
        var userRole = await currentUserService.GetRole();

        if (DoesUserHaveOneOfRoles(userRole, _roles))
        {
            await next();
        }
        else
        {
            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
        }
    }

    private static bool DoesUserHaveOneOfRoles(UserRoleEnum? userRole, IEnumerable<UserRoleEnum> roles)
    {
        return userRole is not null && roles.Any(role => role == userRole);
    }
}