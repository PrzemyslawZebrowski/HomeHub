using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.MarketTypes;

public class GetMarketTypesUseCase : IQueryHandler<GetMarketTypesQuery, IEnumerable<LookupDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetMarketTypesUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<LookupDTO>> Handle(GetMarketTypesQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetMarketTypes(cancellationToken);
    }
}