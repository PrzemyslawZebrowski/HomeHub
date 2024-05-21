using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum OwnershipFormEnum
{
    CooperativeOwnershipRightToUse = 1,
    PerpetualOrLease = 2,
    FullOwnership = 3,
    Share = 4
}

public class OwnershipFormNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)OwnershipFormEnum.CooperativeOwnershipRightToUse, "CooperativeOwnershipRightToUse"},
        {(long)OwnershipFormEnum.PerpetualOrLease, "PerpetualOrLease"},
        {(long)OwnershipFormEnum.FullOwnership, "FullOwnership"},
        {(long)OwnershipFormEnum.Share, "Share"}
    };
}