using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Services;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementById;

public class GetAnnouncementByIdUseCase : IQueryHandler<GetAnnouncementByIdQuery, AnnouncementDTO>
{
    private readonly IAnnouncementQuery _announcementQuery;
    private readonly ICurrentUserService _currentUserService;

    public GetAnnouncementByIdUseCase(IAnnouncementQuery announcementQuery, ICurrentUserService currentUserService)
    {
        _announcementQuery = announcementQuery;
        _currentUserService = currentUserService;
    }

    public async Task<AnnouncementDTO> Handle(GetAnnouncementByIdQuery request, CancellationToken cancellationToken)
    {
        return await _announcementQuery.GetAnnouncementById(request.AnnouncementId, _currentUserService.UserId, cancellationToken);
    }
}