﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.HeatingTypes;

public class GetHeatingTypesUseCase : IQueryHandler<GetHeatingTypesQuery, IEnumerable<LookupDTO>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetHeatingTypesUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<LookupDTO>> Handle(GetHeatingTypesQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetHeatingTypes(cancellationToken);
    }
}