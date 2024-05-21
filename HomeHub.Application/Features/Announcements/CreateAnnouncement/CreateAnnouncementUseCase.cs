using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Command;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.ValueObjects;

namespace HomeHub.Application.Features.Announcements.CreateAnnouncement;

public class CreateAnnouncementUseCase : ICommandHandler<CreateAnnouncementCommand>
{
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IAnnouncementPhotoService _announcementPhotoService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAnnouncementUseCase(
        IAnnouncementRepository announcementRepository,
        IAnnouncementPhotoService announcementPhotoService,
        IUnitOfWork unitOfWork)
    {
        _announcementRepository = announcementRepository;
        _announcementPhotoService = announcementPhotoService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateAnnouncementCommand command, CancellationToken cancellationToken)
    {
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

        var announcement = new Announcement(
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

        _announcementRepository.Create(announcement);

        await _unitOfWork.SaveAsync(cancellationToken);
    }

    private async Task HandleAnnouncementPhotos(Announcement announcement, List<AnnouncementPhotoForm> photos, CancellationToken cancellationToken)
    {
        foreach (var photo in photos)
        {
            await _announcementPhotoService.Store(announcement, photo, cancellationToken);
        }
    }
}