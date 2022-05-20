using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<T> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<T> CreateAsync(T newEntity, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
