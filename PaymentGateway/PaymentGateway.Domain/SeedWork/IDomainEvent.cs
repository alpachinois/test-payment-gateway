using System;

namespace PaymentGateway.Domain.SeedWork
{
    public interface IDomainEvent
    {
        DateTime TimeStampUtc { get; }
    }
}
