using System.Threading;
using System.Threading.Tasks;

namespace HomeHub.Application.Abstraction.Repositories;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken);
}