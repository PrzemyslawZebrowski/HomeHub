using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.AnnouncementTypes;

public class GetAnnouncementTypesUseCase : IQueryHandler<GetAnnouncementTypesQuery, IEnumerable<LookupDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetAnnouncementTypesUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<LookupDTO>> Handle(GetAnnouncementTypesQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetAnnouncementTypes(cancellationToken);
    }
}