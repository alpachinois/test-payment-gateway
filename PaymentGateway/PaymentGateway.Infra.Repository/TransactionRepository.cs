using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateway.Domain;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.Infra.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private ConcurrentBag<Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new ConcurrentBag<Transaction>
            {
                new(new Amount(100, "EUR"), new CardInfo("1234-5678-9123-7897", "123", "Test1", 12, 23),
                    new Merchant("merchant1"), new Shopper("Shopper1"), new Bank("bank1", $"https://localhost:44385/BankPayment/transactions")),
                new(new Amount(100, "USD"), new CardInfo("1234-5678-9123-7897", "123", "Test2", 12, 23),
                    new Merchant("merchant2"), new Shopper("Shopper2"), new Bank("bank1", $"https://localhost:44385/BankPayment/transactions")),
            };

            _transactions.First().Merchant.SetId(new Guid("b8053a59-e449-4e67-8e1b-c588c821eda4"));
            _transactions.First().SetId(new Guid("239287a0-b344-427a-a867-a9142bb7a9e9"));
        }

        public Task<Transaction> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = _transactions.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(result);
        }

        public Task<Transaction> CreateAsync(Transaction newEntity, CancellationToken cancellationToken)
        {
            _transactions.Add(newEntity);

            return Task.FromResult(newEntity);
        }

        public Task<Transaction> UpdateAsync(Transaction entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Transaction entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transaction>> GetAll(Guid merchantId, CancellationToken cancellationToken)
        {
            var results = _transactions.Where(x => x.Merchant.Id == merchantId).ToList();
            
            return Task.FromResult(results);
        }
    }
}
