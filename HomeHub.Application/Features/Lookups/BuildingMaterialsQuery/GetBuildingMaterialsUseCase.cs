using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.BuildingMaterialsQuery;

public class GetBuildingMaterialsUseCase : IQueryHandler<GetBuildingMaterialsQuery, IEnumerable<LookupDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetBuildingMaterialsUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<LookupDTO>> Handle(GetBuildingMaterialsQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetBuildingMaterials(cancellationToken);
    }
}