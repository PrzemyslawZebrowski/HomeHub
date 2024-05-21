using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.SubjectTypes;

public class GetSubjectTypesUseCase : IQueryHandler<GetSubjectTypesQuery, IEnumerable<LookupDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetSubjectTypesUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<LookupDTO>> Handle(GetSubjectTypesQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetSubjectTypes(cancellationToken);
    }
}