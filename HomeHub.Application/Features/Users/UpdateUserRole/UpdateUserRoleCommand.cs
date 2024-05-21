using HomeHub.Domain.Enums.Users;
using HomeHub.Application.Abstraction.CQRS.Command;

namespace HomeHub.Application.Features.Users.UpdateUserRole;

public class UpdateUserRoleCommand : ICommand
{
    public string UserId { get; set; }
    public UserRoleEnum RoleId { get; set; }
}