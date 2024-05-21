using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Application.Common.Model;
using HomeHub.Application.Features.Announcements.GetAdminAnnouncements;
using HomeHub.Application.Features.Announcements.GetAnnouncementById;
using HomeHub.Application.Features.Announcements.GetAnnouncementForAdminPreview;
using HomeHub.Application.Features.Announcements.GetAnnouncementForProfile;
using HomeHub.Application.Features.Announcements.GetAnnouncementsByCurrentUser;
using HomeHub.Application.Features.Announcements.GetAnnouncementsByUser;
using HomeHub.Application.Features.Announcements.GetSearchAnnouncements;
using HomeHub.Application.Features.Lookups.GetAdditionalDetails;
using HomeHub.Domain.Enums.Announcements;
using HomeHub.Domain.Enums.Common;
using HomeHub.Infrastructure.Queries.QueryBuilder;

namespace HomeHub.Infrastructure.Queries;

public class AnnouncementQuery : IAnnouncementQuery
{
    private readonly SqlSelectQueryBuilder _sqlSelectQueryBuilder;
    private readonly ICurrencyService _currencyService;
    private readonly ICurrentUserService _currentUserService;

    public AnnouncementQuery(SqlSelectQueryBuilder sqlSelectQueryBuilder, ICurrencyService currencyService, ICurrentUserService currentUserService)
    {
        _sqlSelectQueryBuilder = sqlSelectQueryBuilder;
        _currencyService = currencyService;
        _currentUserService = currentUserService;
    }

    public async Task<AnnouncementDTO> GetAnnouncementById(long id, string userId, CancellationToken cancellationToken)
    {
        var announcement = await _sqlSelectQueryBuilder.SelectAllProperties<AnnouncementDTO>("Photos", "AdditionalDetails", "IsFavorite")
            .From("[dbo].[VW_Announcements]")
            .Where("Id = @Id", new { id })
            .Where("StatusId = @StatusId", new { StatusId = (long)AnnouncementStatusEnum.Approved })
            .Build()
            .ExecuteSingle<AnnouncementDTO>();

        announcement.Photos = (await GetAnnouncementPhotos(id, cancellationToken)).ToList();

        announcement.AdditionalDetails = (await GetAdditionalDetails(id, cancellationToken)).ToList();

        announcement.PriceAmount = await _currencyService.CalculatePrice(announcement.PriceAmount,
             Enum.Parse<CurrencyEnum>(announcement.PriceCurrency), _currentUserService.Currency, cancellationToken);
        announcement.PriceCurrency = _currentUserService.Currency.ToString();

        if (userId is null)
        {
            return announcement;
        }

        var ids = await GetUserFavoriteAnnouncementIds(userId);

        announcement.IsFavorite = ids.Any(i => i == announcement.Id);

        return announcement;
    }

    public async Task<AnnouncementForProfileDTO> GetAnnouncementForProfileById(long id, string userId, CancellationToken cancellationToken)
    {
        var announcement = await _sqlSelectQueryBuilder.SelectAllProperties<AnnouncementForProfileDTO>("Photos", "AdditionalDetailIds")
            .From("[dbo].[VW_Announcements]")
            .Where("Id = @Id", new { id })
            .Where("CreatedBy = @CreatedBy", new { CreatedBy = userId })
            .Build()
            .ExecuteSingle<AnnouncementForProfileDTO>();

        announcement.Photos = (await GetAnnouncementPhotos(id, cancellationToken)).ToList();

        announcement.AdditionalDetailIds = (await GetAdditionalDetailIds(id, cancellationToken)).ToList();

        return announcement;
    }

    public async Task<AnnouncementForAdminPreviewDTO> GetAnnouncementForAdminPreviewById(long id, CancellationToken cancellationToken)
    {
        var announcement = await _sqlSelectQueryBuilder.SelectAllProperties<AnnouncementForAdminPreviewDTO>("Photos", "AdditionalDetailIds")
            .From("[dbo].[VW_Announcements]")
            .Where("Id = @Id", new { id })
            .Build()
            .ExecuteSingle<AnnouncementForAdminPreviewDTO>();

        announcement.Photos = (await GetAnnouncementPhotos(id, cancellationToken)).ToList();

        announcement.AdditionalDetailIds = (await GetAdditionalDetailIds(id, cancellationToken)).ToList();

        return announcement;
    }

    public async Task<PageDTO<ProfileShortAnnouncementDTO>> GetAnnouncementsByCurrentUser(PaginationCriteria criteria, string title, long? statusId, string userId, CancellationToken cancellationToken)
    {
        var query = _sqlSelectQueryBuilder.SelectAllProperties<ProfileShortAnnouncementDTO>()
            .From("[dbo].[VW_Announcements]")
            .Where("CreatedBy = @CreatedBy", new { CreatedBy = userId });

        if (statusId is not null)
        {
            query.Where("StatusId = @StatusId", new { statusId });
        }

        if (!string.IsNullOrEmpty(title))
        {
            query.Where("Title LIKE @Title", new { Title = "%" + title + "%" });
        }

        var announcements = await query.OrderBy(criteria.OrderBy)
            .BuildPagedQuery(criteria)
            .ExecuteToPage<ProfileShortAnnouncementDTO>();

        foreach (var announcement in announcements.Items)
        {
            announcement.PriceAmount = await _currencyService.CalculatePrice(announcement.PriceAmount, Enum.Parse<CurrencyEnum>(announcement.PriceCurrency), _currentUserService.Currency, cancellationToken);
            announcement.PriceCurrency = _currentUserService.Currency.ToString();
        }

        return announcements;
    }

    public async Task<PageDTO<SearchAnnouncementDTO>> GetFavoriteAnnouncements(PaginationCriteria criteria, string userId, CancellationToken cancellationToken)
    {
        var ids = await GetUserFavoriteAnnouncementIds(userId);

        var page = await _sqlSelectQueryBuilder.SelectAllProperties<SearchAnnouncementDTO>("IsFavorite")
            .From("[dbo].[VW_Announcements]")
            .Where("Id IN @Ids", new { ids })
            .OrderBy(criteria.OrderBy)
            .BuildPagedQuery(criteria)
            .ExecuteToPage<SearchAnnouncementDTO>();

        foreach (var announcement in page.Items)
        {
            announcement.IsFavorite = true;
            announcement.PriceAmount = await _currencyService.CalculatePrice(announcement.PriceAmount, Enum.Parse<CurrencyEnum>(announcement.PriceCurrency), _currentUserService.Currency, cancellationToken);
            announcement.PriceCurrency = _currentUserService.Currency.ToString();
        }

        return page;
    }

    public async Task<PageDTO<AdminAnnouncementDTO>> GetAdminAnnouncements(GetAdminAnnouncementsQuery criteria, CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<AdminAnnouncementDTO>()
            .From("[dbo].[VW_Announcements]")
            .Where("StatusId = @StatusId", new { criteria.StatusId })
            .OrderBy(criteria.OrderBy)
            .BuildPagedQuery(criteria)
            .ExecuteToPage<AdminAnnouncementDTO>();
    }

    public async Task<PageDTO<SearchAnnouncementDTO>> GetSearchAnnouncements(GetSearchAnnouncementsQuery criteria, string userId, CancellationToken cancellationToken)
    {
        _sqlSelectQueryBuilder.SelectAllProperties<SearchAnnouncementDTO>("IsFavorite")
            .From("[dbo].[VW_Announcements]")
            .Where("StatusId = @StatusId", new { StatusId = (long)AnnouncementStatusEnum.Approved })
            .OrderBy(criteria.OrderBy);

        await AddConditionsToSearchQuery(criteria, cancellationToken);

        var announcements = await _sqlSelectQueryBuilder.BuildPagedQuery(criteria)
           .ExecuteToPage<SearchAnnouncementDTO>();

        foreach (var announcement in announcements.Items)
        {
            announcement.PriceAmount = await _currencyService.CalculatePrice(announcement.PriceAmount, Enum.Parse<CurrencyEnum>(announcement.PriceCurrency), _currentUserService.Currency, cancellationToken);
            announcement.PriceCurrency = _currentUserService.Currency.ToString();
        }

        if (userId is null)
        {
            return announcements;
        }

        var ids = await GetUserFavoriteAnnouncementIds(userId);

        foreach (var announcement in announcements.Items)
        {
            announcement.IsFavorite = ids.Any(i => i == announcement.Id);
        }

        return announcements;
    }

    public async Task<PageDTO<SearchAnnouncementDTO>> GetAnnouncementsByUser(GetAnnouncementsByUserQuery criteria, string createdBy, string userId, CancellationToken cancellationToken)
    {
        _sqlSelectQueryBuilder.SelectAllProperties<SearchAnnouncementDTO>("IsFavorite")
            .From("[dbo].[VW_Announcements]")
            .Where("StatusId = @StatusId", new { StatusId = (long)AnnouncementStatusEnum.Approved })
            .Where("CreatedBy = @CreatedBy", new { createdBy })
            .OrderBy(criteria.OrderBy);

        await AddConditionsToSearchQuery(criteria, cancellationToken);

        var announcements = await _sqlSelectQueryBuilder.BuildPagedQuery(criteria)
            .ExecuteToPage<SearchAnnouncementDTO>();

        if (userId is not null)
        {
            var ids = await GetUserFavoriteAnnouncementIds(userId);
            announcements.Items.ForEach(a => { a.IsFavorite = ids.Any(i => i == a.Id); });
        }

        foreach (var announcement in announcements.Items)
        {
            announcement.PriceAmount = await _currencyService.CalculatePrice(announcement.PriceAmount, Enum.Parse<CurrencyEnum>(announcement.PriceCurrency), _currentUserService.Currency, cancellationToken);
            announcement.PriceCurrency = _currentUserService.Currency.ToString();
        }

        return announcements;
    }

    private async Task<IEnumerable<long>> GetUserFavoriteAnnouncementIds(string userId)
    {
        return await _sqlSelectQueryBuilder.Select("AnnouncementId")
            .From("[dbo].[UserFavoriteAnnouncement]")
            .Where("UserId = @UserId", new { userId })
            .Build()
            .ExecuteToList<long>();
    }

    private async Task<IEnumerable<AnnouncementPhotoDTO>> GetAnnouncementPhotos(long announcementId,
        CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<AnnouncementPhotoDTO>()
            .From("[dbo].[AnnouncementPhoto]")
            .Where("AnnouncementId = @AnnouncementId", new { announcementId })
            .Build()
            .ExecuteToList<AnnouncementPhotoDTO>();
    }

    public async Task<IEnumerable<AdditionalDetailDTO>> GetAdditionalDetails(long announcementId, CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<AdditionalDetailDTO>()
            .From("[dbo].[VW_AnnouncementsAdditionalDetails]")
            .Where("AnnouncementId = @AnnouncementId", new { announcementId })
            .Build()
            .ExecuteToList<AdditionalDetailDTO>();
    }

    public async Task<IEnumerable<int>> GetAdditionalDetailIds(long announcementId, CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.Select("Id")
            .From("[dbo].[VW_AnnouncementsAdditionalDetails]")
            .Where("AnnouncementId = @AnnouncementId", new { announcementId })
            .Build()
            .ExecuteToList<int>();
    }

    private async Task AddConditionsToSearchQuery(GetSearchAnnouncementsQuery criteria, CancellationToken cancellationToken)
    {
        if (criteria.SubjectTypeId.HasValue)
        {
            _sqlSelectQueryBuilder.Where("SubjectTypeId = @SubjectTypeId", new { criteria.SubjectTypeId });
        }

        if (criteria.AnnouncementTypeId.HasValue)
        {
            _sqlSelectQueryBuilder.Where("TypeId = @AnnouncementTypeId", new { criteria.AnnouncementTypeId });
        }

        if (criteria.AdvertiserTypeId.HasValue)
        {
            _sqlSelectQueryBuilder.Where("TypeId = @AdvertiserTypeId", new { criteria.AdvertiserTypeId });
        }

        if (criteria.MarketTypeId.HasValue)
        {
            _sqlSelectQueryBuilder.Where("MarketTypeId = @MarketTypeId", new { criteria.MarketTypeId });
        }

        if (criteria.FloorId.HasValue)
        {
            _sqlSelectQueryBuilder.Where("FloorId = @FloorId", new { criteria.FloorId });
        }

        if (criteria.DevelopmentTypeId.HasValue)
        {
            _sqlSelectQueryBuilder.Where("DevelopmentTypeId = @DevelopmentTypeId", new { criteria.DevelopmentTypeId });
        }

        if (criteria.BuildingMaterialId.HasValue)
        {
            _sqlSelectQueryBuilder.Where("BuildingMaterialId = @BuildingMaterialId", new { criteria.BuildingMaterialId });
        }

        if (criteria.BuildingFinishConditionId.HasValue)
        {
            _sqlSelectQueryBuilder.Where("BuildingFinishConditionId = @BuildingFinishConditionId",
                new { criteria.BuildingFinishConditionId });
        }

        if (criteria.AreaMin.HasValue)
        {
            _sqlSelectQueryBuilder.Where("Area >= @AreaMin", new { criteria.AreaMin });
        }

        if (criteria.AreaMax.HasValue)
        {
            _sqlSelectQueryBuilder.Where("Area <= @AreaMax", new { criteria.AreaMax });
        }

        if (criteria.NumberOfRoomsMin.HasValue)
        {
            _sqlSelectQueryBuilder.Where("NumberOfRooms >= @NumberOfRoomsMin", new { criteria.NumberOfRoomsMin });
        }

        if (criteria.NumberOfRoomsMax.HasValue)
        {
            _sqlSelectQueryBuilder.Where("NumberOfRooms <= @NumberOfRoomsMax", new { criteria.NumberOfRoomsMax });
        }

        if (criteria.NumberOfFloorsMin.HasValue)
        {
            _sqlSelectQueryBuilder.Where("NumberOfFloors >= @NumberOfFloorsMin", new { criteria.NumberOfFloorsMin });
        }

        if (criteria.NumberOfFloorsMax.HasValue)
        {
            _sqlSelectQueryBuilder.Where("NumberOfFloors <= @NumberOfFloorsMax", new { criteria.NumberOfFloorsMax });
        }

        if (criteria.BuildYearMin.HasValue)
        {
            _sqlSelectQueryBuilder.Where("BuildYear >= @BuildYearMin", new { criteria.BuildYearMin });
        }

        if (criteria.BuildYearMax.HasValue)
        {
            _sqlSelectQueryBuilder.Where("BuildYear <= @BuildYearMax", new { criteria.BuildYearMax });
        }

        if (criteria.PriceAmountMin.HasValue)
        {
            var usdPriceMin = await _currencyService.CalculatePrice(criteria.PriceAmountMin.Value,
                _currentUserService.Currency, CurrencyEnum.USD, cancellationToken);
            var gbpPriceMin = await _currencyService.CalculatePrice(criteria.PriceAmountMin.Value,
                _currentUserService.Currency, CurrencyEnum.GBP, cancellationToken);
            var plnPriceMin = await _currencyService.CalculatePrice(criteria.PriceAmountMin.Value,
                _currentUserService.Currency, CurrencyEnum.PLN, cancellationToken);
            var eurPriceMin = await _currencyService.CalculatePrice(criteria.PriceAmountMin.Value,
                _currentUserService.Currency, CurrencyEnum.EUR, cancellationToken);

            _sqlSelectQueryBuilder.Where
            (
                "((PriceCurrency = @UsdCurrency AND PriceAmount >= @UsdPriceMin) OR (PriceCurrency = @GbpCurrency AND PriceAmount >= @GbpPriceMin) OR (PriceCurrency = @PlnCurrency AND PriceAmount >= @PlnPriceMin) OR (PriceCurrency = @EurCurrency AND PriceAmount >= @EurPriceMin))",
                new
                {
                    UsdCurrency = CurrencyEnum.USD.ToString(),
                    usdPriceMin,
                    GbpCurrency = CurrencyEnum.GBP.ToString(),
                    gbpPriceMin,
                    PlnCurrency = CurrencyEnum.PLN.ToString(),
                    plnPriceMin,
                    EurCurrency = CurrencyEnum.EUR.ToString(),
                    eurPriceMin
                }
            );
        }

        if (criteria.PriceAmountMax.HasValue)
        {
            var usdPriceMax = await _currencyService.CalculatePrice(criteria.PriceAmountMax.Value,
                _currentUserService.Currency, CurrencyEnum.USD, cancellationToken);
            var gbpPriceMax = await _currencyService.CalculatePrice(criteria.PriceAmountMax.Value,
                _currentUserService.Currency, CurrencyEnum.GBP, cancellationToken);
            var plnPriceMax = await _currencyService.CalculatePrice(criteria.PriceAmountMax.Value,
                _currentUserService.Currency, CurrencyEnum.PLN, cancellationToken);
            var eurPriceMax = await _currencyService.CalculatePrice(criteria.PriceAmountMax.Value,
                _currentUserService.Currency, CurrencyEnum.EUR, cancellationToken);

            _sqlSelectQueryBuilder.Where
            (
                "((PriceCurrency = @UsdCurrency AND PriceAmount <= @UsdPriceMax) OR (PriceCurrency = @GbpCurrency AND PriceAmount <= @GbpPriceMax) OR (PriceCurrency = @PlnCurrency AND PriceAmount <= @PlnPriceMax) OR (PriceCurrency = @EurCurrency AND PriceAmount <= @EurPriceMax))",
                new
                {
                    UsdCurrency = CurrencyEnum.USD.ToString(),
                    usdPriceMax,
                    GbpCurrency = CurrencyEnum.GBP.ToString(),
                    gbpPriceMax,
                    PlnCurrency = CurrencyEnum.PLN.ToString(),
                    plnPriceMax,
                    EurCurrency = CurrencyEnum.EUR.ToString(),
                    eurPriceMax
                }
            );
        }

        if (criteria.Longitude.HasValue && criteria.Latitude.HasValue && criteria.RadiusDistance.HasValue)
        {
            var degrees = criteria.RadiusDistance.Value * 0.009m;
            var latMin = criteria.Latitude.Value - degrees;
            var latMax = criteria.Latitude.Value + degrees;
            var costam = degrees / (decimal)Math.Cos((double)(criteria.Latitude.Value * (decimal)Math.PI / 180));
            var longMin = criteria.Longitude.Value - costam;
            var longMax = criteria.Longitude.Value + costam;

            _sqlSelectQueryBuilder.Where("(Latitude >= @LatMin AND Latitude <= @LatMax AND Longitude >= @LongMin AND Longitude <= @LongMax)", new { latMin, latMax, longMax, longMin });
        }
    }
}