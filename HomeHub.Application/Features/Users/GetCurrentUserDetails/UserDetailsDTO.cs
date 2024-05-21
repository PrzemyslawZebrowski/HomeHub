namespace HomeHub.Application.Features.Users.GetCurrentUserDetails;

public class UserDetailsDTO
{
    public string Id { get; set; }
    public string ContactEmail { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public long AdvertiserTypeId { get; set; }
    public string AdvertiserTypeName { get; set; }
}