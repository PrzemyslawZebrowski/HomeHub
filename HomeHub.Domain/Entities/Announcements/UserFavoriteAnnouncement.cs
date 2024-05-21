using EnsureThat;
using HomeHub.Domain.Entities.Users;

namespace HomeHub.Domain.Entities.Announcements;

public class UserFavoriteAnnouncement
{
    private UserFavoriteAnnouncement()
    {
    }

    public UserFavoriteAnnouncement(User user, long announcementId)
    {
        EnsureArg.IsNotNull(user);

        User = user;
        AnnouncementId = announcementId;
    }

    public string UserId { get; private set; }
    public User User { get; private set; }
    public long AnnouncementId { get; private set; }
}