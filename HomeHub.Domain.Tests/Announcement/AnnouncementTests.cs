using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.Xunit2;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using HomeHub.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace HomeHub.Domain.Tests.Announcement;

public class AnnouncementTests
{
    private static readonly Fixture Fixture = new();
    private readonly Entities.Announcements.Announcement _announcement = Fixture.Create<Entities.Announcements.Announcement>();

    [Theory]
    [AutoData]
    public void Announcement_WithCorrectData_CreatedWithGivenData(SubjectTypeEnum subjectType, AnnouncementTypeEnum announcementType,
        string title, Money price, decimal area, int numberOfRooms, MarketTypeEnum marketType, AdvertiserTypeEnum advertiserType,
        AnnouncementContactDetails contactDetails, AnnouncementLocalization localization, AnnouncementDetails details,
        List<long> additionalDetailIds, AnnouncementMultimedia multimedia)
    {
        // When
        var announcement = new Entities.Announcements.Announcement(subjectType, announcementType, title, price, area, numberOfRooms,
            marketType, advertiserType, contactDetails, localization, details, additionalDetailIds, multimedia);

        // Then
        announcement.SubjectTypeId.ShouldBe((long)subjectType);
        announcement.TypeId.ShouldBe((long)announcementType);
        announcement.MarketTypeId.ShouldBe((long)marketType);
        announcement.AdvertiserTypeId.ShouldBe((long)advertiserType);
        announcement.AdditionalDetails.Count.ShouldBe(additionalDetailIds.Count);
        announcement.Title.ShouldBe(title);
        announcement.Price.ShouldBe(price);
        announcement.Area.ShouldBe(area);
        announcement.NumberOfRooms.ShouldBe(numberOfRooms);
        announcement.StatusId.ShouldBe((long)AnnouncementStatusEnum.Pending);
    }

    [Theory]
    [AutoData]
    public void AddPhoto_WithCorrectData_PhotoAddedToAnnouncement(string fileName, string url, bool isMainPhoto)
    {
        // When
        _announcement.AddPhoto(fileName, url, isMainPhoto);
        var lastAddedPhoto = _announcement.Photos.Last();

        // Then
        lastAddedPhoto.Name.ShouldBe(fileName);
        lastAddedPhoto.Url.ShouldBe(url);
        lastAddedPhoto.IsMainPhoto.ShouldBe(isMainPhoto);
    }

    [Theory]
    [InlineData("   ", "url", false)]
    [InlineData("", "url", false)]
    [InlineData("fileName", "", false)]
    [InlineData("", "", false)]
    [InlineData(null, "", false)]
    [InlineData("", null, false)]
    [InlineData(null, null, false)]
    public void AddPhoto_WithIncorrectData_ThrowArgumentException(string fileName, string url, bool isMainPhoto)
    {
        // When
        // Then
        Should.Throw<ArgumentException>(() => _announcement.AddPhoto(fileName, url, isMainPhoto));
    }

    [Theory]
    [AutoData]
    public void RemovePhoto_WithCorrectData_PhotoDeletedFromAnnouncement(string fileName, string url, bool isMainPhoto)
    {
        // Given
        _announcement.AddPhoto(fileName, url, isMainPhoto);
        AnnouncementPhoto photoToDelete = _announcement.Photos.Last();

        // When
        _announcement.RemovePhoto(photoToDelete);

        // Then
        _announcement.Photos.Count.ShouldBe(0);
    }

    [Fact]
    public void RemovePhoto_WithIncorrectData_ThrowArgumentException()
    {
        // When
        // Then
        Should.Throw<ArgumentException>(() => _announcement.RemovePhoto(null));
    }

    [Theory]
    [AutoData]
    public void SetMainPhoto_WithNoMainPhoto_SetMainPhotoInAnnouncement(string fileName, string url)
    {
        // Given
        _announcement.AddPhoto(fileName, url, false);
        AnnouncementPhoto addedPhoto = _announcement.Photos.Last();

        // When
        _announcement.SetMainPhoto(addedPhoto.Id);
        AnnouncementPhoto mainPhoto = _announcement.Photos.Last();
        // Then
        mainPhoto.IsMainPhoto.ShouldBeTrue();
    }

    [Theory]
    [AutoData]
    public void SetMainPhoto_WithMainPhoto_SetMainPhotoInAnnouncement(string fileName, string url, string fileName2, string url2)
    {
        // Given
        _announcement.AddPhoto(fileName, url, true);
        _announcement.AddPhoto(fileName2, url2, false);
        _announcement.Photos.Last().Id = 1;
        AnnouncementPhoto addedPhoto = _announcement.Photos.Last();

        // When
        _announcement.SetMainPhoto(addedPhoto.Id);

        AnnouncementPhoto firstPhoto = _announcement.Photos.First();
        AnnouncementPhoto secondPhoto = _announcement.Photos.Last();

        // Then
        firstPhoto.IsMainPhoto.ShouldBeFalse();
        secondPhoto.IsMainPhoto.ShouldBeTrue();
    }
}