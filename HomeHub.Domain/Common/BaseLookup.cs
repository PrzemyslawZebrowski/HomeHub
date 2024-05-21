using EnsureThat;

namespace HomeHub.Domain.Common;

public abstract class BaseLookup : BaseEntity
{
    protected BaseLookup()
    { }

    protected BaseLookup(long id, string name)
    {
        EnsureArg.IsNotNullOrEmpty(name, nameof(name));

        Id = id;
        Name = name;
    }

    public string Name { get; set; }
}