using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Application.Common.Model;

namespace HomeHub.Application.Features.Announcements.GetSearchAnnouncements;

public class GetSearchAnnouncementsUseCase : IQueryHandler<GetSearchAnnouncementsQuery, PageDTO<SearchAnnouncementDTO>>
{
    private readonly IAnnouncementQuery _announcementQuery;
    private readonly ICurrentUserService _currentUserService;

    public GetSearchAnnouncementsUseCase(IAnnouncementQuery announcementQuery, ICurrentUserService currentUserService)
    {
        _announcementQuery = announcementQuery;
        _currentUserService = currentUserService;
    }

    public async Task<PageDTO<SearchAnnouncementDTO>> Handle(GetSearchAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        return await _announcementQuery.GetSearchAnnouncements(request, _currentUserService.UserId, cancellationToken);
    }
}