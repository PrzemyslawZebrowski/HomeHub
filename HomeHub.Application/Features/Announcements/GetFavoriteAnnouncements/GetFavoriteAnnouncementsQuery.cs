using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Common.Model;
using HomeHub.Application.Features.Announcements.GetSearchAnnouncements;

namespace HomeHub.Application.Features.Announcements.GetFavoriteAnnouncements;

public record GetFavoriteAnnouncementsQuery : PaginationCriteria, IQuery<PageDTO<SearchAnnouncementDTO>>;