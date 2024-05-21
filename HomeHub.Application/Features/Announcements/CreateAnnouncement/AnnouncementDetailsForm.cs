using System;
using System.Collections.Generic;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.CreateAnnouncement;

public class AnnouncementDetailsForm
{
    public string Description { get; set; }
    public DevelopmentTypeEnum DevelopmentTypeId { get; set; }
    public FloorEnum FloorId { get; set; }
    public int NumberOfFloors { get; set; }
    public BuildingMaterialEnum BuildingMaterialId { get; set; }
    public WindowTypeEnum WindowTypeId { get; set; }
    public HeatingTypeEnum HeatingTypeId { get; set; }
    public int BuildYear { get; set; }
    public BuildingFinishConditionEnum BuildingFinishConditionId { get; set; }
    public OwnershipFormEnum OwnershipFormId { get; set; }
    public DateTime AvailableFrom { get; set; }
    public List<long> AdditionalDetailIds { get; set; }
}