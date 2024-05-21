using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Users;

public class UserRole : BaseLookup
{
    private UserRole() : base()
    { }

    public UserRole(int id, string name) : base(id, name)
    {
    }
}