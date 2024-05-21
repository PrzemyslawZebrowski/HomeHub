using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Command;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Application.Abstraction.Services;

namespace HomeHub.Application.Features.Users.RegisterUser;

public class RegisterUserUseCase : ICommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserUseCase(IUserRepository userRepository, ICurrentUserService currentUserService, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.Users.User(_currentUserService.UserId, _currentUserService.Email);
        _userRepository.Create(user);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}