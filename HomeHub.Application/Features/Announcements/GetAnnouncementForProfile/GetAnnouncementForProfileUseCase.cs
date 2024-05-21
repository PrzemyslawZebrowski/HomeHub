using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Services;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementForProfile;

public class GetAnnouncementForProfileUseCase : IQueryHandler<GetAnnouncementForProfileQuery, AnnouncementForProfileDTO>
{
    private readonly IAnnouncementQuery _announcementQuery;
    private readonly ICurrentUserService _currentUserService;

    public GetAnnouncementForProfileUseCase(IAnnouncementQuery announcementQuery, ICurrentUserService currentUserService)
    {
        _announcementQuery = announcementQuery;
        _currentUserService = currentUserService;
    }

    public async Task<AnnouncementForProfileDTO> Handle(GetAnnouncementForProfileQuery request, CancellationToken cancellationToken)
    {
        return await _announcementQuery.GetAnnouncementForProfileById(request.AnnouncementId, _currentUserService.UserId, cancellationToken);
    }
}