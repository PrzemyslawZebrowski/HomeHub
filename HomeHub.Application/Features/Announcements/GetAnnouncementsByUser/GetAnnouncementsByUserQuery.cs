using HomeHub.Application.Features.Announcements.GetSearchAnnouncements;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementsByUser;

public record GetAnnouncementsByUserQuery(SubjectTypeEnum? SubjectTypeId, AnnouncementTypeEnum? AnnouncementTypeId, AdvertiserTypeEnum? AdvertiserTypeId, MarketTypeEnum? MarketTypeId, FloorEnum? FloorId, DevelopmentTypeEnum? DevelopmentTypeId, BuildingMaterialEnum? BuildingMaterialId, BuildingFinishConditionEnum? BuildingFinishConditionId, decimal? Longitude, decimal? Latitude, decimal? RadiusDistance, decimal? PriceAmountMin, decimal? PriceAmountMax, decimal? AreaMin, decimal? AreaMax, int? NumberOfRoomsMin, int? NumberOfRoomsMax, int? NumberOfFloorsMin, int? NumberOfFloorsMax, int? BuildYearMin, int? BuildYearMax) : GetSearchAnnouncementsQuery(SubjectTypeId, AnnouncementTypeId, AdvertiserTypeId, MarketTypeId, FloorId, DevelopmentTypeId, BuildingMaterialId, BuildingFinishConditionId, Longitude, Latitude, RadiusDistance, PriceAmountMin, PriceAmountMax, AreaMin, AreaMax, NumberOfRoomsMin, NumberOfRoomsMax, NumberOfFloorsMin, NumberOfFloorsMax, BuildYearMin, BuildYearMax)
{
    public string UserId { get; set; }
}