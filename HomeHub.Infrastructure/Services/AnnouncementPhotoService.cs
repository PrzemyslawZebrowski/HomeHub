using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Application.Features.Announcements.CreateAnnouncement;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Infrastructure.BlobStorage.Models;
using HomeHub.Infrastructure.BlobStorage.Services;

namespace HomeHub.Infrastructure.Services;

public class AnnouncementPhotoService : IAnnouncementPhotoService
{
    private readonly IBlobService _blobService;

    public AnnouncementPhotoService(IBlobService blobService)
    {
        _blobService = blobService;
    }

    public async Task Store(Announcement announcement, AnnouncementPhotoForm photoForm, CancellationToken cancellationToken = default)
    {
        EnsureArg.IsNotNull(announcement, nameof(announcement));
        EnsureArg.IsNotNull(photoForm, nameof(photoForm));

        var blobFile = new BlobFile(photoForm.File);
        var blobUploadInfo = await _blobService.Store(BlobContainer.AnnouncementPhotos, blobFile, cancellationToken);

        announcement.AddPhoto(blobUploadInfo.Name, blobUploadInfo.Url, photoForm.IsMainPhoto);
    }

    public async Task Remove(Announcement announcement, long photoId, CancellationToken cancellationToken = default)
    {
        EnsureArg.IsNotNull(announcement, nameof(announcement));
        EnsureArg.IsNotDefault(photoId, nameof(photoId));

        var photo = announcement.Photos.Find(p => p.Id == photoId);

        if (photo is not null)
        {
            await _blobService.Remove(BlobContainer.AnnouncementPhotos, photo.Name, cancellationToken);
            announcement.RemovePhoto(photo);
        }
    }
}