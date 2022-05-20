using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.SeedWork;

namespace PaymentGateway.Domain
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<List<Transaction>> GetAll(Guid merchantId, CancellationToken cancellationToken);
    }
}
