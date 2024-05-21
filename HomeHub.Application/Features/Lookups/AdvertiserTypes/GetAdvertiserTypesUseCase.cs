using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.AdvertiserTypes;

public class GetAdvertiserTypesUseCase : IQueryHandler<GetAdvertiserTypesQuery, IEnumerable<LookupDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetAdvertiserTypesUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<LookupDTO>> Handle(GetAdvertiserTypesQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetAdvertiserTypes(cancellationToken);
    }
}