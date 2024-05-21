using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;

namespace HomeHub.Application.Features.Lookups.GetAdditionalDetails;

public class GetAdditionalDetailsUseCase : IQueryHandler<GetAdditionalDetailsQuery, IEnumerable<AdditionalDetailDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetAdditionalDetailsUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<AdditionalDetailDTO>> Handle(GetAdditionalDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetAdditionalDetails(cancellationToken);
    }
}