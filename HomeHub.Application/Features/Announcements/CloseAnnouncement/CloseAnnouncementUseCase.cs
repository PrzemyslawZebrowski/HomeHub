using System;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Command;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.CloseAnnouncement;

public class CloseAnnouncementUseCase : ICommandHandler<CloseAnnouncementCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly ICurrentUserService _currentUserService;

    public CloseAnnouncementUseCase(IUnitOfWork unitOfWork, IAnnouncementRepository announcementRepository, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _announcementRepository = announcementRepository;
        _currentUserService = currentUserService;
    }

    public async Task Handle(CloseAnnouncementCommand command, CancellationToken cancellationToken)
    {
        var announcement = await _announcementRepository.GetAsync(command.AnnouncementId, cancellationToken);

        if (_currentUserService.UserId != announcement.CreatedBy)
        {
            throw new UnauthorizedAccessException();
        }

        announcement.SetStatus(AnnouncementStatusEnum.Closed);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}