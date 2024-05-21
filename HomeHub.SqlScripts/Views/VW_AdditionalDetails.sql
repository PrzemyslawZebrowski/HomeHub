CREATE VIEW [dbo].[VW_AdditionalDetails] AS 
SELECT 
	d.[Id],
	d.[Name],
	d.[GroupId],
	g.[Name] as GroupName,
	d.[CreatedOn],
	d.[CreatedBy]
FROM [dbo].[AdditionalDetail] d
INNER JOIN [dbo].[DetailsGroup] g ON d.GroupId = g.Id
