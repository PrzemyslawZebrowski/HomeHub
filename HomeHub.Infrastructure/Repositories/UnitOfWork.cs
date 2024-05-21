using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomeHub.Application.Abstraction.Providers;
using HomeHub.Application.Abstraction.Repositories;
using HomeHub.Application.Abstraction.Services;
using HomeHub.Domain.Common;
using HomeHub.Infrastructure.Context;
using HomeHub.Infrastructure.Providers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeHub.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly HomeHubContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMediator _mediator;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UnitOfWork(HomeHubContext context, ICurrentUserService currentUserService, IMediator mediator, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _currentUserService = currentUserService;
        _mediator = mediator;
        _dateTimeProvider = dateTimeProvider;
    }

    public Task SaveAsync(CancellationToken cancellationToken)
    {
        PublishDomainEvents(cancellationToken);

        var entries = _context.ChangeTracker.Entries<BaseEntity>()
            .Where(x => x is { State: EntityState.Added or EntityState.Modified });


        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.CreatedOn = _dateTimeProvider.UtcNow;
                entityEntry.Entity.CreatedBy = _currentUserService.UserId;
            }

            entityEntry.Entity.UpdatedOn = _dateTimeProvider.UtcNow;
            entityEntry.Entity.UpdatedBy = _currentUserService.UserId;
        }

        return _context.SaveChangesAsync(cancellationToken);
    }

    private async void PublishDomainEvents(CancellationToken cancellationToken)
    {
        var events = _context.ChangeTracker.Entries<BaseEventStoringEntity>()
            .Where(x => x.Entity.DomainEvents.Any())
            .Select(x => x.Entity)
            .SelectMany(e => e.DomainEvents);

        foreach (var @event in events)
        {
            await _mediator.Publish(@event, cancellationToken);
        }
    }
}