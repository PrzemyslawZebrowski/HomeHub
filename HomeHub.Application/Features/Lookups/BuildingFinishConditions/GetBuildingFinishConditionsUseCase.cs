using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.BuildingFinishConditions;

public class GetBuildingFinishConditionsUseCase : IQueryHandler<GetBuildingFinishConditionsQuery, IEnumerable<LookupDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetBuildingFinishConditionsUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<LookupDTO>> Handle(GetBuildingFinishConditionsQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetBuildingFinishConditions(cancellationToken);
    }
}