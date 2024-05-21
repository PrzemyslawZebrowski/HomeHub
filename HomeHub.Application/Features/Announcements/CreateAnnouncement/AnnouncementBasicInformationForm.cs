using System.Text.Json.Serialization;
using HomeHub.Domain.Enums.Announcements;
using HomeHub.Domain.Enums.Common;

namespace HomeHub.Application.Features.Announcements.CreateAnnouncement;

public class AnnouncementBasicInformationForm
{
    public string Title { get; set; }
    public decimal PriceAmount { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CurrencyEnum PriceCurrency { get; set; }

    public AdvertiserTypeEnum AdvertiserTypeId { get; set; }
    public MarketTypeEnum MarketTypeId { get; set; }
    public decimal Area { get; set; }
    public int NumberOfRooms { get; set; }
}