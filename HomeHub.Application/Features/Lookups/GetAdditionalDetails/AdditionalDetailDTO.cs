using HomeHub.Application.Features.Lookups.Model;

namespace HomeHub.Application.Features.Lookups.GetAdditionalDetails;

public class AdditionalDetailDTO : LookupDTO
{
    public long GroupId { get; set; }
    public string GroupName { get; set; }
}