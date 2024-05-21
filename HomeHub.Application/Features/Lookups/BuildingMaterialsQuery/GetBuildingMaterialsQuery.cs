using System.Collections.Generic;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.BuildingMaterialsQuery;

public class GetBuildingMaterialsQuery : IQuery<IEnumerable<LookupDTO>>
{
}