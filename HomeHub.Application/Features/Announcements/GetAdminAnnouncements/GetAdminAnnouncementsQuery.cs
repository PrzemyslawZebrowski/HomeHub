using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Common.Model;

namespace HomeHub.Application.Features.Announcements.GetAdminAnnouncements;

public record GetAdminAnnouncementsQuery(long StatusId) : PaginationCriteria, IQuery<PageDTO<AdminAnnouncementDTO>>;