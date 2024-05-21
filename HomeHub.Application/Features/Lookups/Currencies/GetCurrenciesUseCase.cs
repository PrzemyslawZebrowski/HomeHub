using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;

namespace HomeHub.Application.Features.Lookups.Currencies;

public class GetCurrenciesUseCase : IQueryHandler<GetCurrenciesQuery, IEnumerable<string>>
{
    private readonly ILookupQuery _lookupQuery;

    public GetCurrenciesUseCase(ILookupQuery lookupQuery)
    {
        _lookupQuery = lookupQuery;
    }

    public async Task<IEnumerable<string>> Handle(GetCurrenciesQuery query, CancellationToken cancellationToken)
    {
        return await _lookupQuery.GetCurrencies(cancellationToken);
    }
}