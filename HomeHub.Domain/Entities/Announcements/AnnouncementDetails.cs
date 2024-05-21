using System;
using System.Collections.Generic;
using HomeHub.Domain.Common;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Domain.Entities.Announcements;

public class AnnouncementDetails : ValueObject
{
    private AnnouncementDetails()
    {
    }

    public AnnouncementDetails(string description, DevelopmentTypeEnum developmentType, FloorEnum floor, int numberOfFloors, BuildingMaterialEnum buildingMaterial, WindowTypeEnum windowType, HeatingTypeEnum heatingType, int buildYear, BuildingFinishConditionEnum buildingFinishCondition, OwnershipFormEnum ownershipForm, DateTime availableFrom)
    {
        Description = description;
        DevelopmentTypeId = (long)developmentType;
        FloorId = (long)floor;
        NumberOfFloors = numberOfFloors;
        BuildingMaterialId = (long)buildingMaterial;
        WindowTypeId = (long)windowType;
        HeatingTypeId = (long)heatingType;
        BuildYear = buildYear;
        BuildingFinishConditionId = (long)buildingFinishCondition;
        OwnershipFormId = (long)ownershipForm;
        AvailableFrom = availableFrom;
    }

    public string Description { get; private set; }
    public long DevelopmentTypeId { get; private set; }
    public long FloorId { get; private set; }
    public int NumberOfFloors { get; private set; }
    public long BuildingMaterialId { get; private set; }
    public long WindowTypeId { get; private set; }
    public long HeatingTypeId { get; private set; }
    public int BuildYear { get; private set; }
    public long BuildingFinishConditionId { get; private set; }
    public long OwnershipFormId { get; private set; }
    public DateTime AvailableFrom { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Description;
        yield return DevelopmentTypeId;
        yield return FloorId;
        yield return NumberOfFloors;
        yield return BuildingMaterialId;
        yield return WindowTypeId;
        yield return HeatingTypeId;
        yield return BuildYear;
        yield return BuildingFinishConditionId;
        yield return OwnershipFormId;
        yield return AvailableFrom;
    }
}