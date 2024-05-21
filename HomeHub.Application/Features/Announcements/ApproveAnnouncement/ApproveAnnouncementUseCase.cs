using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.CQRS.Command;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.ApproveAnnouncement;

public class ApproveAnnouncementUseCase : ICommandHandler<ApproveAnnouncementCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAnnouncementRepository _announcementRepository;

    public ApproveAnnouncementUseCase(IUnitOfWork unitOfWork, IAnnouncementRepository announcementRepository)
    {
        _unitOfWork = unitOfWork;
        _announcementRepository = announcementRepository;
    }

    public async Task Handle(ApproveAnnouncementCommand command, CancellationToken cancellationToken)
    {
        var announcement = await _announcementRepository.GetAsync(command.AnnouncementId, cancellationToken);

        announcement.SetStatus(AnnouncementStatusEnum.Approved);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}