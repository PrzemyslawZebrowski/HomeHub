using HomeHub.Application.Abstraction.Providers;
using System;

namespace HomeHub.Infrastructure.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}

