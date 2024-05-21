using System;

namespace HomeHub.Domain.Common;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset UpdatedOn { get; set; }
    public string UpdatedBy { get; set; }
}