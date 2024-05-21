using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Common.Model;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementsByCurrentUser;

public record GetAnnouncementsByCurrentUserQuery(long? StatusId, string Title) : PaginationCriteria, IQuery<PageDTO<ProfileShortAnnouncementDTO>>;