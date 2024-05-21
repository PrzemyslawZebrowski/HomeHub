using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.GetAdditionalDetails;
using HomeHub.Application.Features.Lookups.Model;
using HomeHub.Domain.Enums.Common;
using HomeHub.Infrastructure.Queries.QueryBuilder;

namespace HomeHub.Infrastructure.Queries;

public class LookupQuery : ILookupQuery
{
    private readonly SqlSelectQueryBuilder _sqlSelectQueryBuilder;

    public LookupQuery(SqlSelectQueryBuilder sqlSelectQueryBuilder)

    {
        _sqlSelectQueryBuilder = sqlSelectQueryBuilder;
    }

    public async Task<IEnumerable<LookupDTO>> GetRoles(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[UserRole]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetAdvertiserTypes(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[AdvertiserType]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetAnnouncementTypes(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[AnnouncementType]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetMarketTypes(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[MarketType]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetSubjectTypes(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[SubjectType]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetAnnouncementStatuses(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[AnnouncementStatus]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetBuildingFinishConditions(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[BuildingFinishCondition]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetBuildingMaterials(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[BuildingMaterial]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetDevelopmentTypes(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[DevelopmentType]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetFloors(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[Floor]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetHeatingTypes(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[HeatingType]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetOwnershipForms(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[OwnershipForm]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<LookupDTO>> GetWindowTypes(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<LookupDTO>()
            .From("[dbo].[WindowType]")
            .Build()
            .ExecuteToList<LookupDTO>();
    }

    public async Task<IEnumerable<string>> GetCurrencies(CancellationToken cancellationToken)
    {
        return Enum.GetValues(typeof(CurrencyEnum)).Cast<CurrencyEnum>().Select(e => e.ToString());
    }

    public async Task<IEnumerable<AdditionalDetailDTO>> GetAdditionalDetails(CancellationToken cancellationToken)
    {
        return await _sqlSelectQueryBuilder.SelectAllProperties<AdditionalDetailDTO>()
            .From("[dbo].[VW_AdditionalDetails]")
            .Build()
            .ExecuteToList<AdditionalDetailDTO>();
    }
}