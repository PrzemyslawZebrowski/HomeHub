using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Common.Model;
using HomeHub.Application.Features.Announcements.GetAdminAnnouncements;
using HomeHub.Application.Features.Announcements.GetAnnouncementById;
using HomeHub.Application.Features.Announcements.GetAnnouncementForAdminPreview;
using HomeHub.Application.Features.Announcements.GetAnnouncementForProfile;
using HomeHub.Application.Features.Announcements.GetAnnouncementsByCurrentUser;
using HomeHub.Application.Features.Announcements.GetAnnouncementsByUser;
using HomeHub.Application.Features.Announcements.GetSearchAnnouncements;

namespace HomeHub.Application.Abstraction.Queries;

public interface IAnnouncementQuery
{
    Task<AnnouncementDTO> GetAnnouncementById(long id, string userId, CancellationToken cancellationToken);

    Task<AnnouncementForProfileDTO> GetAnnouncementForProfileById(long id, string userId, CancellationToken cancellationToken);

    Task<AnnouncementForAdminPreviewDTO> GetAnnouncementForAdminPreviewById(long id, CancellationToken cancellationToken);

    Task<PageDTO<ProfileShortAnnouncementDTO>> GetAnnouncementsByCurrentUser(PaginationCriteria criteria, string title, long? statusId, string userId, CancellationToken cancellationToken);

    Task<PageDTO<SearchAnnouncementDTO>> GetFavoriteAnnouncements(PaginationCriteria criteria, string userId, CancellationToken cancellationToken);

    Task<PageDTO<AdminAnnouncementDTO>> GetAdminAnnouncements(GetAdminAnnouncementsQuery criteria, CancellationToken cancellationToken);

    Task<PageDTO<SearchAnnouncementDTO>> GetSearchAnnouncements(GetSearchAnnouncementsQuery criteria, string userId, CancellationToken cancellationToken);

    Task<PageDTO<SearchAnnouncementDTO>> GetAnnouncementsByUser(GetAnnouncementsByUserQuery criteria, string createdBy, string userId, CancellationToken cancellationToken);
}