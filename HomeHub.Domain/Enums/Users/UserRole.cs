using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Users;

public enum UserRoleEnum
{
    Admin = 1,
    User = 2,
    Moderator = 3
}

public class UserRoleNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)UserRoleEnum.Admin, "Admin"},
        {(long)UserRoleEnum.User, "User"},
        {(long)UserRoleEnum.Moderator, "Moderator"}
    };
}