using System.Collections.Generic;

namespace PaymentGateway.Domain.SeedWork
{
    public interface IAggregateRoot : IEntity
    {
        IEnumerable<IDomainEvent> Events { get; }

        void AddEvent(IDomainEvent domainEvent);
    }
}
