using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Common.Model;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.GetSearchAnnouncements;

public record GetSearchAnnouncementsQuery(
    SubjectTypeEnum? SubjectTypeId,
    AnnouncementTypeEnum? AnnouncementTypeId,
    AdvertiserTypeEnum? AdvertiserTypeId,
    MarketTypeEnum? MarketTypeId,
    FloorEnum? FloorId,
    DevelopmentTypeEnum? DevelopmentTypeId,
    BuildingMaterialEnum? BuildingMaterialId,
    BuildingFinishConditionEnum? BuildingFinishConditionId,
    decimal? Longitude,
    decimal? Latitude,
    decimal? RadiusDistance,
    decimal? PriceAmountMin,
    decimal? PriceAmountMax,
    decimal? AreaMin,
    decimal? AreaMax,
    int? NumberOfRoomsMin,
    int? NumberOfRoomsMax,
    int? NumberOfFloorsMin,
    int? NumberOfFloorsMax,
    int? BuildYearMin,
    int? BuildYearMax) : PaginationCriteria, IQuery<PageDTO<SearchAnnouncementDTO>>;