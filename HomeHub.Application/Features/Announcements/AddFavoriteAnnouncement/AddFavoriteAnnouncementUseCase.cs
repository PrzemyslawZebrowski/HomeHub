using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Command;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Application.Common.Exceptions;

namespace HomeHub.Application.Features.Announcements.AddFavoriteAnnouncement;

public class AddFavoriteAnnouncementUseCase : ICommandHandler<AddFavoriteAnnouncementCommand>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserRepository _userRepository;
    private readonly IAnnouncementRepository _announcementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddFavoriteAnnouncementUseCase(ICurrentUserService currentUserService, IUnitOfWork unitOfWork, IUserRepository userRepository, IAnnouncementRepository announcementRepository)
    {
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _announcementRepository = announcementRepository;
    }

    public async Task Handle(AddFavoriteAnnouncementCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(_currentUserService.UserId, cancellationToken);
        var announcement = await _announcementRepository.GetAsync(command.AnnouncementId, cancellationToken);

        if (user == null || announcement == null)
        {
            throw new NotFoundException(
                $"User {_currentUserService.UserId} or announcement {command.AnnouncementId} not found");
        }

        user.AddFavoriteAnnouncement(announcement.Id);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}