CREATE VIEW [dbo].[VW_Announcements] AS 
SELECT 
	a.[Id],
	a.[Title],
	a.[Description],
	a.[PriceAmount],
	a.[PriceCurrency],
	a.[Area], 
	a.[NumberOfRooms],
	a.[TypeId],
	t.[Name] as TypeNAme,
	a.[AdvertiserTypeId],
	adv.[Name] as AdvertiserTypeName,
	a.[MarketTypeId],
	m.[Name] as MarketTypeName,
	a.[SubjectTypeId],
	s.[Name] as SubjectTypeName,
	a.[StatusId],
	astatus.[Name] as StatusName,
	a.[BuildingFinishConditionId],
	bfc.[Name] as BuildingFinishConditionName,
	a.[BuildingMaterialId],
	bm.[Name] as BuildingMaterialName,
	a.[DevelopmentTypeId],
	dt.[Name] as DevelopmentTypeName,
	a.[FloorId],
	f.[Name] as FloorName,
	a.[HeatingTypeId],
	ht.[Name] as HeatingTypeName,
	a.[OwnershipFormId],
	o.[Name] as OwnershipFormName,
	a.[WindowTypeId],
	wt.[Name] as WindowTypeName,
	a.[AvailableFrom] as AvailableFrom,
	a.[BuildYear] as BuildYear,
	a.[NumberOfFloors] as NumberOfFloors,
	a.[AdvertiserName],
	a.[AdvertiserEmail],
	a.[AdvertiserPhoneNumber],
	a.[Address],
	a.[Latitude],
	a.[Longitude],
	a.[VideoUrl],
	a.[VirtualWalkUrl],
	photo.[Url] as PhotoUrl,
	a.[CreatedOn],
	a.[CreatedBy]
FROM [dbo].[Announcement] a
LEFT JOIN [dbo].[AnnouncementType] t ON a.TypeId = t.Id
LEFT JOIN [dbo].[AdvertiserType] adv ON a.AdvertiserTypeId = adv.Id
LEFT JOIN [dbo].[MarketType] m ON a.MarketTypeId = m.Id
LEFT JOIN [dbo].[SubjectType] s ON a.SubjectTypeId = s.Id
LEFT JOIN [dbo].[AnnouncementStatus] astatus ON a.StatusId = astatus.Id
LEFT JOIN [dbo].[BuildingFinishCondition] bfc ON a.BuildingFinishConditionId = bfc.Id
LEFT JOIN [dbo].[BuildingMaterial] bm ON a.BuildingMaterialId = bm.Id
LEFT JOIN [dbo].[DevelopmentType] dt ON a.DevelopmentTypeId = dt.Id
LEFT JOIN [dbo].[Floor] f ON a.FloorId = f.Id
LEFT JOIN [dbo].[HeatingType] ht ON a.HeatingTypeId = ht.Id
LEFT JOIN [dbo].[OwnershipForm] o ON a.OwnershipFormId = o.Id
LEFT JOIN [dbo].[WindowType] wt ON a.WindowTypeId = wt.Id
LEFT JOIN [dbo].[AnnouncementPhoto] photo ON a.Id = photo.AnnouncementId AND photo.IsMainPhoto = 1
