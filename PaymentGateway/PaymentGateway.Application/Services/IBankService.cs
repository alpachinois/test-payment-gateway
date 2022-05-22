using System.Threading;
using System.Threading.Tasks;
using PaymentGateway.Application.Commands.TransactionPayment;

namespace PaymentGateway.Application.Services
{
    public interface IBankService
    {
        Task<BankResponse> ProcessPaymentAsync(CardInfo cardInfo, Bank bank, Amount amount, CancellationToken cancellationToken);
    }
}
