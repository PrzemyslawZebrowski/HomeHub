using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EnsureThat;
using HomeHub.Infrastructure.BlobStorage.Models;

namespace HomeHub.Infrastructure.BlobStorage.Services;

public class BlobService : IBlobService
{
    private const long MaxBlobSize = 10485760;
    private readonly BlobServiceClient _blobServiceClient;

    public BlobService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<BlobUploadInfo> Store(BlobContainer container, BlobFile blob, CancellationToken cancellationToken = default)
    {
        if (blob.Size > MaxBlobSize)
        {
            throw new ArgumentException("Blob size is too big", nameof(blob));
        }

        var containerClient = await GetBlobContainerClientAsync(container, cancellationToken);

        var blobClient = containerClient.GetBlobClient(blob.Name);
        await blobClient.UploadAsync(blob.FileStream, new BlobHttpHeaders { ContentType = blob.ContentType }, cancellationToken: cancellationToken);

        return new BlobUploadInfo(blob.Name, blobClient.Uri.AbsoluteUri);
    }

    public async Task Remove(BlobContainer container, string blobName, CancellationToken cancellationToken = default)
    {
        var containerClient = await GetBlobContainerClientAsync(container, cancellationToken);

        var blobClient = containerClient.GetBlobClient(blobName);
        await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);
    }

    private async Task<BlobContainerClient> GetBlobContainerClientAsync(BlobContainer container, CancellationToken cancellationToken = default)
    {
        EnsureArg.IsNotNull(container, nameof(container));

        var containerClient = _blobServiceClient.GetBlobContainerClient(container.Name);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob, cancellationToken: cancellationToken);

        return containerClient;
    }
}