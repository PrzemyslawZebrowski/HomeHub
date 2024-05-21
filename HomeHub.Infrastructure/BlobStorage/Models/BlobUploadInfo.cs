namespace HomeHub.Infrastructure.BlobStorage.Models;

public class BlobUploadInfo
{
    public BlobUploadInfo(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public string Name { get; }
    public string Url { get; }
}