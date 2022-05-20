using System.Collections.Generic;

namespace PaymentGateway.Domain.SeedWork
{
    public abstract class AggregateRootBase : EntityBase, IAggregateRoot
    {
        private readonly IList<IDomainEvent> _events = new List<IDomainEvent>();
        public IEnumerable<IDomainEvent> Events => _events;

        public void AddEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }
    }
}
