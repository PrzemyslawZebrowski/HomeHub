using System.Threading.Tasks;
using HomeHub.Application.Features.Users.GetCurrentUserDetails;
using HomeHub.Application.Features.Users.GetCurrentUserInfo;
using HomeHub.Application.Features.Users.GetUserDetails;
using HomeHub.Application.Features.Users.GetUsers;
using HomeHub.Application.Features.Users.RegisterUser;
using HomeHub.Application.Features.Users.UpdateCurrentUserDetails;
using HomeHub.Application.Features.Users.UpdateUserRole;
using HomeHub.Domain.Enums.Users;
using HomeHub.Infrastructure.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeHub.Api.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/users/register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("/users/info")]
    public async Task<IActionResult> GetCurrentUserInfo()
    {
        var result = await _mediator.Send(new GetCurrentUserInfoQuery());
        return Ok(result);
    }

    [HttpGet("/users")]
    [AuthorizeUserRole(UserRoleEnum.Admin, UserRoleEnum.Moderator)]
    public async Task<IActionResult> GetUsers([FromQuery] GetUsersQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("/users/{userId}/role")]
    [AuthorizeUserRole(UserRoleEnum.Admin)]
    public async Task<IActionResult> UpdateUserRole([FromRoute] string userId, [FromBody] UpdateUserRoleCommand command)
    {
        command.UserId = userId;

        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("/users/{userId}/details")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserDetails([FromRoute] GetUserDetailsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("/users/details")]

    public async Task<IActionResult> GetCurrentUserDetails()
    {
        var result = await _mediator.Send(new GetCurrentUserDetailsQuery());
        return Ok(result);
    }

    [HttpPut("/users/details")]
    public async Task<IActionResult> UpdateCurrentUserDetails([FromBody] UpdateCurrentUserDetails command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}