using HomeHub.Domain.Auth;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

namespace HomeHub.Api.Extensions;

public static class AuthExtensions
{
    public static void ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMicrosoftIdentityWebApiAuthentication(configuration);

        services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.ApiReader, policy => policy.RequireScope(Scopes.Read));
        });

        services.AddMvcCore(options =>
        {
            options.Filters.Add(new AuthorizeFilter(Policies.ApiReader));
        });
    }
}