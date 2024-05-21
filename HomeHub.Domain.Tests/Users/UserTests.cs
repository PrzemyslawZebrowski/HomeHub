using AutoFixture;
using AutoFixture.Xunit2;
using HomeHub.Domain.Entities.Users;
using HomeHub.Domain.Enums.Users;
using Shouldly;
using Xunit;

namespace HomeHub.Domain.Tests.Users;

public class UserTests
{
    private static readonly Fixture Fixture = new();
    private readonly User _user = Fixture.Create<User>();

    [Theory]
    [AutoData]
    public void User_WithCorrectData_CreatedWithGivenData(string id, string email)
    {
        // When
        var user = new User(id, email);

        // Then
        user.Id.ShouldBe(id);
        user.Email.ShouldBe(email);
        user.RoleId.ShouldBe((long)UserRoleEnum.User);
    }

    [Theory]
    [AutoData]
    public void SetRole_ShouldRoleBeUpdated(UserRoleEnum role)
    {
        // When
        _user.SetRole(role);

        // Then
        _user.RoleId.ShouldBe((long)role);
    }
}