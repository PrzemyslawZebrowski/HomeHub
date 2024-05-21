CREATE VIEW [dbo].[VW_AnnouncementsAdditionalDetails] AS 
SELECT 
	d.[Id],
	d.[Name],
	d.[GroupId],
	g.[Name] as GroupName,
	aad.[AnnouncementId],
	d.[CreatedOn],
	d.[CreatedBy]
FROM [dbo].[Announcement] a
INNER JOIN [dbo].[AnnouncementAdditionalDetail] aad ON a.Id = aad.AnnouncementId
INNER JOIN [dbo].[AdditionalDetail] d ON aad.AdditionalDetailId = d.Id
INNER JOIN [dbo].[DetailsGroup] g ON d.GroupId = g.Id
