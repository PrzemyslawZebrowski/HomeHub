using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.WindowTypes;

public class GetWindowTypesUseCase : IQueryHandler<GetWindowTypesQuery, IEnumerable<LookupDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetWindowTypesUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<LookupDTO>> Handle(GetWindowTypesQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetWindowTypes(cancellationToken);
    }
}