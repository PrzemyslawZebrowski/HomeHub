using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Command;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Application.Features.Announcements.CreateAnnouncement;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.ValueObjects;

namespace HomeHub.Application.Features.Announcements.UpdateAnnouncement;

public class UpdateAnnouncementUseCase : ICommandHandler<UpdateAnnouncementCommand>
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IAnnouncementPhotoService _announcementPhotoService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public UpdateAnnouncementUseCase(
        IAnnouncementRepository announcementRepository,
        IAnnouncementPhotoService announcementPhotoService,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUserService)
    {
        _announcementRepository = announcementRepository;
        _announcementPhotoService = announcementPhotoService;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task Handle(UpdateAnnouncementCommand command, CancellationToken cancellationToken)
    {
        var announcement = await _announcementRepository.GetWithSpecifiedDependenciesAsync(
            command.AnnouncementId,
            new() { a => a.Photos, a => a.AdditionalDetails },
            cancellationToken);

        if (_currentUserService.UserId != announcement.CreatedBy)
        {
            throw new UnauthorizedAccessException();
        }

        var price = new Money(command.BasicInformation.PriceAmount, command.BasicInformation.PriceCurrency);

        var contactDetails = new AnnouncementContactDetails(
            command.ContactDetails.AdvertiserName,
            command.ContactDetails.AdvertiserEmail,
            command.ContactDetails.AdvertiserPhoneNumber);

        var localization = new AnnouncementLocalization(
            command.Localization.Address,
            command.Localization.Latitude,
            command.Localization.Longitude);

        var details = new AnnouncementDetails(
            command.Details.Description,
            command.Details.DevelopmentTypeId,
            command.Details.FloorId,
            command.Details.NumberOfFloors,
            command.Details.BuildingMaterialId,
            command.Details.WindowTypeId,
            command.Details.HeatingTypeId,
            command.Details.BuildYear,
            command.Details.BuildingFinishConditionId,
            command.Details.OwnershipFormId,
            command.Details.AvailableFrom);

        var multimedia = new AnnouncementMultimedia(
            command.Multimedia.VideoUrl,
            command.Multimedia.VirtualWalkUrl);

        announcement.UpdateAnnouncement(
            command.SubjectType.SubjectTypeId,
            command.SubjectType.TypeId,
            command.BasicInformation.Title,
            price,
            command.BasicInformation.Area,
            command.BasicInformation.NumberOfRooms,
            command.BasicInformation.MarketTypeId,
            command.BasicInformation.AdvertiserTypeId,
            contactDetails,
            localization,
            details,
            command.Details.AdditionalDetailIds,
            multimedia);

        await HandleAnnouncementPhotos(announcement, command.Multimedia.Photos, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);
    }

    private async Task HandleAnnouncementPhotos(Announcement announcement, List<AnnouncementPhotoForm> photos,
        CancellationToken cancellationToken)
    {
        var photosIdsToRemove = announcement.Photos.Select(p => p.Id)
            .Where(id => !photos.Select(p => p.Id).ToList().Contains(id)).ToList();

        foreach (var photoId in photosIdsToRemove)
        {
            await _announcementPhotoService.Remove(announcement, photoId, cancellationToken);
        }

        var hasMainPhotoBeenSet = false;
        var newPhotos = photos.Where(p => p.Id == default);

        foreach (var photo in newPhotos)
        {
            await _announcementPhotoService.Store(announcement, photo, cancellationToken);
            if (photo.IsMainPhoto)
            {
                hasMainPhotoBeenSet = true;
            }
        }

        if (!hasMainPhotoBeenSet)
        {
            var mainPhotoId = photos.Find(p => p.IsMainPhoto).Id;
            announcement.SetMainPhoto(mainPhotoId);
        }
    }
}