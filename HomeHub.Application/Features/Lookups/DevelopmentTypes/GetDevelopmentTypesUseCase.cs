using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.DevelopmentTypes;

public class GetDevelopmentTypesUseCase : IQueryHandler<GetDevelopmentTypesQuery, IEnumerable<LookupDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetDevelopmentTypesUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<LookupDTO>> Handle(GetDevelopmentTypesQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetDevelopmentTypes(cancellationToken);
    }
}