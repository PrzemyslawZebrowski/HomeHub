using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Application.Common.Model;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementsByCurrentUser;

public class GetAnnouncementsByCurrentUserUseCase : IQueryHandler<GetAnnouncementsByCurrentUserQuery, PageDTO<ProfileShortAnnouncementDTO>>
{
    private readonly IAnnouncementQuery _announcementQuery;
    private readonly ICurrentUserService _currentUserService;

    public GetAnnouncementsByCurrentUserUseCase(IAnnouncementQuery announcementQuery, ICurrentUserService currentUserService)
    {
        _announcementQuery = announcementQuery;
        _currentUserService = currentUserService;
    }

    public async Task<PageDTO<ProfileShortAnnouncementDTO>> Handle(GetAnnouncementsByCurrentUserQuery request, CancellationToken cancellationToken)
    {
        return await _announcementQuery.GetAnnouncementsByCurrentUser(request, request.Title, request.StatusId, _currentUserService.UserId, cancellationToken);
    }
}