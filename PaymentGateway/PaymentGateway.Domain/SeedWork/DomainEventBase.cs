using System;

namespace PaymentGateway.Domain.SeedWork
{
    public abstract class DomainEventBase : IDomainEvent
    {
        public DateTime TimeStampUtc { get; private set; } = DateTime.UtcNow;
    }
}
