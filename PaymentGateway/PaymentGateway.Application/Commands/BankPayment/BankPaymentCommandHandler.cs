using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentGateway.Application.Services;

namespace PaymentGateway.Application.Commands.BankPayment
{
    public class BankPaymentCommandHandler : IRequestHandler<BankPaymentCommand, BankResponse>
    {
        private readonly IBankService _bankService;

        public BankPaymentCommandHandler(IBankService bankService)
        {
            _bankService = bankService;
        }

        public async Task<BankResponse> Handle(BankPaymentCommand request, CancellationToken cancellationToken)
        {
            var result = await _bankService.ProcessPaymentAsync(request.CardInfo, request.Bank, request.Amount, cancellationToken);

            return result;
        }
    }
}
