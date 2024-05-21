using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Command;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.RefuseAnnouncement;

public class RefuseAnnouncementUseCase : ICommandHandler<RefuseAnnouncementCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAnnouncementRepository _announcementRepository;

    public RefuseAnnouncementUseCase(IUnitOfWork unitOfWork, IAnnouncementRepository announcementRepository)
    {
        _unitOfWork = unitOfWork;
        _announcementRepository = announcementRepository;
    }

    public async Task Handle(RefuseAnnouncementCommand command, CancellationToken cancellationToken)
    {
        var announcement = await _announcementRepository.GetAsync(command.AnnouncementId, cancellationToken);

        announcement.SetStatus(AnnouncementStatusEnum.Refused);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}