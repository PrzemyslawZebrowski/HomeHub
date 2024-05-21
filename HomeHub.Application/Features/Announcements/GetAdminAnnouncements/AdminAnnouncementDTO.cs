using System;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.GetAdminAnnouncements;

public class AdminAnnouncementDTO
{
    public long Id { get; set; }
    public string PhotoUrl { get; set; }
    public string Title { get; set; }
    public decimal PriceAmount { get; set; }
    public string PriceCurrency { get; set; }
    public decimal Area { get; set; }
    public string Address { get; set; }
    public AnnouncementStatusEnum StatusId { get; set; }
    public string StatusName { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}