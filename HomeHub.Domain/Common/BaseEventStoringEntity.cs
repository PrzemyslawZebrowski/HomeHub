using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeHub.Domain.Common;

public abstract class BaseEventStoringEntity : BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    public void ClearEvents() => _domainEvents.Clear();
}