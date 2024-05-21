CREATE VIEW [dbo].[VW_Users] AS 
SELECT 
	u.[Id],
	u.[Email],
	u.[ContactEmail],
	u.[Name],
	u.[PhoneNumber],
	u.[AdvertiserTypeId],
	atype.[Name] as AdvertiserTypeName,
	u.[RoleId],
	ur.[Name] as RoleName,
	u.CreatedOn
FROM [dbo].[User] u
LEFT JOIN [dbo].[UserRole] ur ON u.RoleId = ur.Id
LEFT JOIN [dbo].[AdvertiserType] atype ON u.AdvertiserTypeId = atype.Id
