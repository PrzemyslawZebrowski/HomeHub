using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace HomeHub.Infrastructure.BlobStorage.Models;

public class BlobFile
{
    private BlobFile(string name, Stream fileStream, string contentType, long size)
    {
        Name = GenerateBlobName(Path.GetExtension(name));
        FileStream = fileStream;
        ContentType = contentType;
        Size = size;
    }

    public BlobFile(IFormFile file) : this(file.FileName, file.OpenReadStream(), file.ContentType, file.Length)
    { }

    public string Name { get; }
    public Stream FileStream { get; }
    public string ContentType { get; }
    public long Size { get; }

    private static string GenerateBlobName(string extension)
    {
        return $"{Guid.NewGuid()}{extension}";
    }
}