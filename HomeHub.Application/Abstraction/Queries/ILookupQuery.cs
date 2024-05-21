using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Features.Lookups.GetAdditionalDetails;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Abstraction.Queries;

public interface ILookupQuery
{
    Task<IEnumerable<LookupDTO>> GetRoles(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetAdvertiserTypes(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetAnnouncementTypes(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetMarketTypes(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetSubjectTypes(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetAnnouncementStatuses(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetBuildingFinishConditions(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetBuildingMaterials(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetDevelopmentTypes(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetFloors(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetHeatingTypes(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetOwnershipForms(CancellationToken cancellationToken);

    Task<IEnumerable<LookupDTO>> GetWindowTypes(CancellationToken cancellationToken);

    Task<IEnumerable<string>> GetCurrencies(CancellationToken cancellationToken);

    Task<IEnumerable<AdditionalDetailDTO>> GetAdditionalDetails(CancellationToken cancellationToken);
}