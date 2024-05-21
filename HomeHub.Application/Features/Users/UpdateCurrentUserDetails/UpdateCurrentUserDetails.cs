using HomeHub.Application.Abstraction.CQRS.Command;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Users.UpdateCurrentUserDetails;

public class UpdateCurrentUserDetails : ICommand
{
    public string ContactEmail { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public AdvertiserTypeEnum AdvertiserTypeId { get; set; }
}