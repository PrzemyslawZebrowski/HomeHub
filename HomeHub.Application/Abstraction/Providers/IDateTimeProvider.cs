using System;

namespace HomeHub.Application.Abstraction.Providers;

public interface IDateTimeProvider
{
    public DateTimeOffset UtcNow { get; }
}

