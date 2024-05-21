using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.GetSearchAnnouncements;

public class SearchAnnouncementDTO
{
    public long Id { get; set; }
    public string PhotoUrl { get; set; }
    public string Title { get; set; }
    public decimal PriceAmount { get; set; }
    public string PriceCurrency { get; set; }
    public decimal Area { get; set; }
    public string Address { get; set; }
    public int NumberOfRooms { get; set; }
    public AdvertiserTypeEnum AdvertiserTypeId { get; set; }
    public string AdvertiserTypeName { get; set; }
    public bool IsFavorite { get; set; }
}