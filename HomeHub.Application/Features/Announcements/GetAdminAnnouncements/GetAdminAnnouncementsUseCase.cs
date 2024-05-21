using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;
using HomeHub.Application.Common.Model;

namespace HomeHub.Application.Features.Announcements.GetAdminAnnouncements;

public class GetAdminAnnouncementsUseCase : IQueryHandler<GetAdminAnnouncementsQuery, PageDTO<AdminAnnouncementDTO>>
{
    private readonly IAnnouncementQuery _announcementQuery;

    public GetAdminAnnouncementsUseCase(IAnnouncementQuery announcementQuery)
    {
        _announcementQuery = announcementQuery;
    }

    public async Task<PageDTO<AdminAnnouncementDTO>> Handle(GetAdminAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        return await _announcementQuery.GetAdminAnnouncements(request, cancellationToken);
    }
}