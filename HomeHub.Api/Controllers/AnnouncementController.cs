using System.Threading.Tasks;
using HomeHub.Application.Features.Announcements.AddFavoriteAnnouncement;
using HomeHub.Application.Features.Announcements.ApproveAnnouncement;
using HomeHub.Application.Features.Announcements.CloseAnnouncement;
using HomeHub.Application.Features.Announcements.CreateAnnouncement;
using HomeHub.Application.Features.Announcements.GetAdminAnnouncements;
using HomeHub.Application.Features.Announcements.GetAnnouncementById;
using HomeHub.Application.Features.Announcements.GetAnnouncementForAdminPreview;
using HomeHub.Application.Features.Announcements.GetAnnouncementForProfile;
using HomeHub.Application.Features.Announcements.GetAnnouncementsByCurrentUser;
using HomeHub.Application.Features.Announcements.GetAnnouncementsByUser;
using HomeHub.Application.Features.Announcements.GetFavoriteAnnouncements;
using HomeHub.Application.Features.Announcements.GetSearchAnnouncements;
using HomeHub.Application.Features.Announcements.RefuseAnnouncement;
using HomeHub.Application.Features.Announcements.RemoveFavoriteAnnouncement;
using HomeHub.Application.Features.Announcements.UpdateAnnouncement;
using HomeHub.Domain.Enums.Users;
using HomeHub.Infrastructure.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeHub.Api.Controllers;

[ApiController]
public class AnnouncementController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnnouncementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region MainAnnouncements

    [HttpGet("/announcements")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSearchAnnouncements([FromQuery] GetSearchAnnouncementsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("/announcements/{announcementId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAnnouncementById([FromRoute] GetAnnouncementByIdQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    #endregion

    #region ProfileAnnouncements

    [HttpGet("/profile/announcements")]
    public async Task<IActionResult> GetAnnouncementsByCurrentUser([FromQuery] GetAnnouncementsByCurrentUserQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("/profile/announcements/{announcementId}")]
    public async Task<IActionResult> GetAnnouncementForProfile([FromRoute] GetAnnouncementForProfileQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("/profile/announcements")]
    public async Task<IActionResult> CreateAnnouncement([FromForm] CreateAnnouncementCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("/profile/announcements/{announcementId}")]
    public async Task<IActionResult> UpdateAnnouncement([FromRoute] long announcementId, [FromForm] UpdateAnnouncementCommand command)
    {
        command.AnnouncementId = announcementId;
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("/profile/announcements/{announcementId}/close")]
    public async Task<IActionResult> CloseAnnouncement([FromRoute] CloseAnnouncementCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion

    #region FavoriteAnnouncements

    [HttpGet("/profile/announcements/favorite")]
    public async Task<IActionResult> GetFavoriteAnnouncements([FromQuery] GetFavoriteAnnouncementsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("/profile/announcements/favorite/{announcementId}")]
    public async Task<IActionResult> AddFavoriteAnnouncement([FromRoute] AddFavoriteAnnouncementCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("/profile/announcements/favorite/{announcementId}")]
    public async Task<IActionResult> RemoveFavoriteAnnouncement([FromRoute] RemoveFavoriteAnnouncementCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    #endregion FavoriteAnnouncements

    #region AdminPanelAnnouncements

    [AuthorizeUserRole(UserRoleEnum.Admin, UserRoleEnum.Moderator)]
    [HttpPut("/admin/announcements/{announcementId}/approve")]
    public async Task<IActionResult> ApproveAnnouncement([FromRoute] ApproveAnnouncementCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [AuthorizeUserRole(UserRoleEnum.Admin, UserRoleEnum.Moderator)]
    [HttpPut("/admin/announcements/{announcementId}/refuse")]
    public async Task<IActionResult> RefuseAnnouncement([FromRoute] RefuseAnnouncementCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [AuthorizeUserRole(UserRoleEnum.Admin, UserRoleEnum.Moderator)]
    [HttpGet("/admin/announcements")]
    public async Task<IActionResult> GetAdminAnnouncements([FromQuery] GetAdminAnnouncementsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [AuthorizeUserRole(UserRoleEnum.Admin, UserRoleEnum.Moderator)]
    [HttpGet("/admin/announcements/{announcementId}")]
    public async Task<IActionResult> GetAdminAnnouncementForAdminPreview([FromRoute] GetAnnouncementForAdminPreviewQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    #endregion AdminPanelAnnouncements

    #region UserAnnouncements

    [HttpGet("/users/{userId}/announcements")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAnnouncementsByUser([FromRoute] string userId, [FromQuery] GetAnnouncementsByUserQuery query)
    {
        query.UserId = userId;

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    #endregion
}