using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Infrastructure.Context;

namespace HomeHub.Infrastructure.Repositories;

public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
{
    public AnnouncementRepository(HomeHubContext context) : base(context)
    {
    }
}