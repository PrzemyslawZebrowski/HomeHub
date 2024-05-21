using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Command;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Domain.Entities.Users;

namespace HomeHub.Application.Features.Announcements.RemoveFavoriteAnnouncement;

public class RemoveFavoriteAnnouncementUseCase : ICommandHandler<RemoveFavoriteAnnouncementCommand>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveFavoriteAnnouncementUseCase(ICurrentUserService currentUserService, IUnitOfWork unitOfWork,
        IUserRepository userRepository)
    {
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task Handle(RemoveFavoriteAnnouncementCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetWithSpecifiedDependenciesAsync(_currentUserService.UserId,
            new List<Expression<Func<User, object>>> { u => u.FavoriteAnnouncements },
            cancellationToken);

        user.DeleteFavoriteAnnouncement(command.AnnouncementId);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}