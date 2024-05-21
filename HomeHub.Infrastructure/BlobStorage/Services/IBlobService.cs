using System.Threading;
using System.Threading.Tasks;
using HomeHub.Infrastructure.BlobStorage.Models;

namespace HomeHub.Infrastructure.BlobStorage.Services;

public interface IBlobService
{
    public Task<BlobUploadInfo> Store(BlobContainer container, BlobFile blob, CancellationToken cancellationToken = default);

    public Task Remove(BlobContainer container, string blobName, CancellationToken cancellationToken = default);
}