using System.Collections.Generic;
using EnsureThat;
using HomeHub.Domain.Common;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using HomeHub.Domain.Enums.Users;

namespace HomeHub.Domain.Entities.Users;

public class User : BaseEntity
{
    private User()
    {
    }

    public User(string id, string email)
    {
        EnsureArg.IsNotNullOrEmpty(id, nameof(id));
        EnsureArg.IsNotNullOrEmpty(email, nameof(email));

        Id = id;
        Email = email;
        RoleId = (long)UserRoleEnum.User;
    }

    public new string Id { get; init; }
    public string Email { get; private set; }
    public string ContactEmail { get; private set; }
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
    public long? AdvertiserTypeId { get; private set; }
    public long RoleId { get; private set; }
    public List<UserFavoriteAnnouncement> FavoriteAnnouncements { get; private set; } = new();

    public void SetRole(UserRoleEnum role)
    {
        RoleId = (long)role;
    }

    public void AddFavoriteAnnouncement(long announcementId)
    {
        FavoriteAnnouncements.Add(new UserFavoriteAnnouncement(this, announcementId));
    }

    public void DeleteFavoriteAnnouncement(long announcementId)
    {
        var favoriteAnnouncement = FavoriteAnnouncements.Find(a => announcementId == a.AnnouncementId);

        if (favoriteAnnouncement is not null)
        {
            FavoriteAnnouncements.Remove(favoriteAnnouncement);
        }
    }

    public void UpdateUserDetails(string contactEmail, string name, string phoneNumber, AdvertiserTypeEnum advertiserType)
    {
        ContactEmail = contactEmail;
        Name = name;
        PhoneNumber = phoneNumber;
        AdvertiserTypeId = (long)advertiserType;
    }
}