using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum DetailsGroupEnum
{
    Media = 1,
    Security = 2,
    Equipment = 3,
    Additional = 4,
    Remote = 5
}

public class DetailsGroupNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)DetailsGroupEnum.Media, "Media"},
        {(long)DetailsGroupEnum.Security, "Security"},
        {(long)DetailsGroupEnum.Equipment, "Equipment"},
        {(long)DetailsGroupEnum.Additional, "Additional"},
        {(long)DetailsGroupEnum.Remote, "Remote"},
    };
}