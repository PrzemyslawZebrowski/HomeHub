using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Abstraction.Queries;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementForAdminPreview;

public class GetAnnouncementForAdminPreviewUseCase : IQueryHandler<GetAnnouncementForAdminPreviewQuery, AnnouncementForAdminPreviewDTO>
{
    private readonly IAnnouncementQuery _announcementQuery;

    public GetAnnouncementForAdminPreviewUseCase(IAnnouncementQuery announcementQuery)
    {
        _announcementQuery = announcementQuery;
    }

    public async Task<AnnouncementForAdminPreviewDTO> Handle(GetAnnouncementForAdminPreviewQuery request, CancellationToken cancellationToken)
    {
        return await _announcementQuery.GetAnnouncementForAdminPreviewById(request.AnnouncementId, cancellationToken);
    }
}