using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Features.Announcements.CreateAnnouncement;
using HomeHub.Domain.Entities.Announcements;

namespace HomeHub.Application.Abstraction.Services;

public interface IAnnouncementPhotoService
{
    public Task Store(Announcement announcement, AnnouncementPhotoForm photoForm, CancellationToken cancellationToken = default);

    public Task Remove(Announcement announcement, long photoId, CancellationToken cancellationToken = default);
}