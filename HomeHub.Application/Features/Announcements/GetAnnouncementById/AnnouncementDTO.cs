using System;
using System.Collections.Generic;
using HomeHub.Application.Features.Announcements.GetAnnouncementForProfile;
using HomeHub.Application.Features.Lookups.GetAdditionalDetails;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementById;

public class AnnouncementDTO
{
    public long Id { get; set; }
    public SubjectTypeEnum SubjectTypeId { get; set; }
    public string SubjectTypeName { get; set; }
    public AnnouncementTypeEnum TypeId { get; set; }
    public string TypeName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal PriceAmount { get; set; }
    public string PriceCurrency { get; set; }
    public AdvertiserTypeEnum AdvertiserTypeId { get; set; }
    public string AdvertiserTypeName { get; set; }
    public MarketTypeEnum MarketTypeId { get; set; }
    public string MarketTypeName { get; set; }
    public decimal Area { get; set; }
    public int NumberOfRooms { get; set; }
    public BuildingFinishConditionEnum BuildingFinishConditionId { get; set; }
    public string BuildingFinishConditionName { get; set; }
    public BuildingMaterialEnum BuildingMaterialId { get; set; }
    public string BuildingMaterialName { get; set; }
    public DevelopmentTypeEnum DevelopmentTypeId { get; set; }
    public string DevelopmentTypeName { get; set; }
    public FloorEnum FloorId { get; set; }
    public string FloorName { get; set; }
    public int NumberOfFloors { get; set; }
    public HeatingTypeEnum HeatingTypeId { get; set; }
    public string HeatingTypeName { get; set; }
    public int BuildYear { get; set; }
    public OwnershipFormEnum OwnershipFormId { get; set; }
    public string OwnershipFormName { get; set; }
    public WindowTypeEnum WindowTypeId { get; set; }
    public string WindowTypeName { get; set; }
    public DateTime AvailableFrom { get; set; }
    public string AdvertiserName { get; set; }
    public string AdvertiserEmail { get; set; }
    public string AdvertiserPhoneNumber { get; set; }
    public string CreatedBy { get; set; }
    public string Address { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string VideoUrl { get; set; }
    public string VirtualWalkUrl { get; set; }
    public bool IsFavorite { get; set; }
    public List<AnnouncementPhotoDTO> Photos { get; set; }
    public List<AdditionalDetailDTO> AdditionalDetails { get; set; }
}