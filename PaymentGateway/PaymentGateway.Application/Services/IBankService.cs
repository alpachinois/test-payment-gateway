using System.Threading;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.Application.Services
{
    public interface IBankService
    {
        Task<BankResponse> ProcessPaymentAsync(CardInfo cardInfo, Bank bank, Amount amount, CancellationToken cancellationToken);
    }
}
