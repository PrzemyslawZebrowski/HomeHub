using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Application.Common.Model;
using HomeHub.Application.Features.Announcements.GetSearchAnnouncements;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementsByUser;

public class GetAnnouncementsByUserUseCase : IQueryHandler<GetAnnouncementsByUserQuery, PageDTO<SearchAnnouncementDTO>>
{
    private readonly IAnnouncementQuery _announcementQuery;
    private readonly ICurrentUserService _currentUserService;

    public GetAnnouncementsByUserUseCase(IAnnouncementQuery announcementQuery, ICurrentUserService currentUserService)
    {
        _announcementQuery = announcementQuery;
        _currentUserService = currentUserService;
    }

    public async Task<PageDTO<SearchAnnouncementDTO>> Handle(GetAnnouncementsByUserQuery request, CancellationToken cancellationToken)
    {
        return await _announcementQuery.GetAnnouncementsByUser(request, request.UserId, _currentUserService.UserId, cancellationToken);
    }
}