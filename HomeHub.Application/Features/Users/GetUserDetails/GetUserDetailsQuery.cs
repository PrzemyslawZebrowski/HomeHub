using HomeHub.Application.Abstraction.CQRS.Query;
using HomeHub.Application.Features.Users.GetCurrentUserDetails;

namespace HomeHub.Application.Features.Users.GetUserDetails;

public class GetUserDetailsQuery : IQuery<UserDetailsDTO>
{
    public string UserId { get; set; }
}