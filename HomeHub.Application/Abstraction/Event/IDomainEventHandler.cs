using HomeHub.Domain.Common;
using MediatR;

namespace HomeHub.Application.Abstraction.Event;

public interface IDomainEventHandler<in T> : INotificationHandler<T> where T : IDomainEvent
{ }