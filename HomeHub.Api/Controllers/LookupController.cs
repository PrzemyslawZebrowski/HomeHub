using System.Threading.Tasks;
using HomeHub.Application.Features.Lookups.AdvertiserTypes;
using HomeHub.Application.Features.Lookups.AnnouncementStatuses;
using HomeHub.Application.Features.Lookups.AnnouncementTypes;
using HomeHub.Application.Features.Lookups.BuildingFinishConditions;
using HomeHub.Application.Features.Lookups.BuildingMaterialsQuery;
using HomeHub.Application.Features.Lookups.Currencies;
using HomeHub.Application.Features.Lookups.DevelopmentTypes;
using HomeHub.Application.Features.Lookups.Floors;
using HomeHub.Application.Features.Lookups.GetAdditionalDetails;
using HomeHub.Application.Features.Lookups.HeatingTypes;
using HomeHub.Application.Features.Lookups.MarketTypes;
using HomeHub.Application.Features.Lookups.OwnershipForms;
using HomeHub.Application.Features.Lookups.Roles;
using HomeHub.Application.Features.Lookups.SubjectTypes;
using HomeHub.Application.Features.Lookups.WindowTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeHub.Api.Controllers;

[AllowAnonymous]
[ApiController]
public class LookupController : ControllerBase
{
    private readonly IMediator _mediator;

    public LookupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/lookups/users/roles")]
    public async Task<IActionResult> GetRoles()
    {
        var result = await _mediator.Send(new GetRolesQuery());
        return Ok(result);
    }

    #region Announcements

    [HttpGet("/lookups/announcements/advertiser-types")]
    public async Task<IActionResult> GetAdvertiserTypes()
    {
        var result = await _mediator.Send(new GetAdvertiserTypesQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/types")]
    public async Task<IActionResult> GetAnnouncementTypes()
    {
        var result = await _mediator.Send(new GetAnnouncementTypesQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/market-types")]
    public async Task<IActionResult> GetMarketTypes()
    {
        var result = await _mediator.Send(new GetMarketTypesQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/subject-types")]
    public async Task<IActionResult> GetSubjectTypes()
    {
        var result = await _mediator.Send(new GetSubjectTypesQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/statuses")]
    public async Task<IActionResult> GetAnnouncementStatuses()
    {
        var result = await _mediator.Send(new GetAnnouncementStatusesQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/building-finish-conditions")]
    public async Task<IActionResult> GetBuildingFinishConditions()
    {
        var result = await _mediator.Send(new GetBuildingFinishConditionsQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/building-materials")]
    public async Task<IActionResult> GetBuildingMaterials()
    {
        var result = await _mediator.Send(new GetBuildingMaterialsQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/development-types")]
    public async Task<IActionResult> GetDevelopmentTypes()
    {
        var result = await _mediator.Send(new GetDevelopmentTypesQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/floors")]
    public async Task<IActionResult> GetFloors()
    {
        var result = await _mediator.Send(new GetFloorsQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/heating-types")]
    public async Task<IActionResult> GetHeatingTypes()
    {
        var result = await _mediator.Send(new GetHeatingTypesQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/ownership-forms")]
    public async Task<IActionResult> GetOwnershipForms()
    {
        var result = await _mediator.Send(new GetOwnershipFormsQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/window-types")]
    public async Task<IActionResult> GetWindowTypes()
    {
        var result = await _mediator.Send(new GetWindowTypesQuery());
        return Ok(result);
    }

    [HttpGet("/lookups/announcements/details")]
    public async Task<IActionResult> GetAdditionalDetails()
    {
        var result = await _mediator.Send(new GetAdditionalDetailsQuery());
        return Ok(result);
    }

    #endregion Announcements

    [HttpGet("/lookups/currencies")]
    public async Task<IActionResult> GetCurrencies()
    {
        var result = await _mediator.Send(new GetCurrenciesQuery());
        return Ok(result);
    }
}