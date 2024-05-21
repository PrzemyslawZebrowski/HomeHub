using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Application.Common.Model;
using HomeHub.Application.Features.Announcements.GetSearchAnnouncements;

namespace HomeHub.Application.Features.Announcements.GetFavoriteAnnouncements;

public class
    GetFavoriteAnnouncementsUseCase : IQueryHandler<GetFavoriteAnnouncementsQuery, PageDTO<SearchAnnouncementDTO>>
{
    private readonly IAnnouncementQuery _announcementQuery;
    private readonly ICurrentUserService _currentUserService;

    public GetFavoriteAnnouncementsUseCase(IAnnouncementQuery announcementQuery, ICurrentUserService currentUserService)
    {
        _announcementQuery = announcementQuery;
        _currentUserService = currentUserService;
    }

    public async Task<PageDTO<SearchAnnouncementDTO>> Handle(GetFavoriteAnnouncementsQuery request,
        CancellationToken cancellationToken)
    {
        return await _announcementQuery.GetFavoriteAnnouncements(request, _currentUserService.UserId,
            cancellationToken);
    }
}