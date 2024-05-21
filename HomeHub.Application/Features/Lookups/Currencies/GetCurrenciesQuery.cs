using System.Collections.Generic;
using HomeHub.Application.Abstraction.CQRS.Query;

namespace HomeHub.Application.Features.Lookups.Currencies;

public class GetCurrenciesQuery : IQuery<IEnumerable<string>>
{
}