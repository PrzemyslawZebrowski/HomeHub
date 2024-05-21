namespace HomeHub.Infrastructure.BlobStorage.Models;

public class BlobContainer
{
    public string Name { get; }

    private BlobContainer(string name)
    {
        Name = name;
    }

    public static BlobContainer AnnouncementPhotos => new("announcement-photos");
}