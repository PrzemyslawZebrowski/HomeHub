using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.OwnershipForms;

public class GetOwnershipFormsUseCase : IQueryHandler<GetOwnershipFormsQuery, IEnumerable<LookupDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetOwnershipFormsUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<LookupDTO>> Handle(GetOwnershipFormsQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetOwnershipForms(cancellationToken);
    }
}