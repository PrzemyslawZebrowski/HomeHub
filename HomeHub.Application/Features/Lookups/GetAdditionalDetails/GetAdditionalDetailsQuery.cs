using System.Collections.Generic;
using HomeHub.Application.Abstraction.CQRS.Query;

namespace HomeHub.Application.Features.Lookups.GetAdditionalDetails;

public record GetAdditionalDetailsQuery : IQuery<IEnumerable<AdditionalDetailDTO>>;