using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Command;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Application.Abstraction.Services;

namespace HomeHub.Application.Features.Users.UpdateCurrentUserDetails;

public class UpdateCurrentUserDetailsUseCase : ICommandHandler<UpdateCurrentUserDetails>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;

    public UpdateCurrentUserDetailsUseCase(IUserRepository userRepository, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }

    public async Task Handle(Users.UpdateCurrentUserDetails.UpdateCurrentUserDetails request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(_currentUserService.UserId, cancellationToken);
        user.UpdateUserDetails(request.ContactEmail, request.Name, request.PhoneNumber, request.AdvertiserTypeId);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}