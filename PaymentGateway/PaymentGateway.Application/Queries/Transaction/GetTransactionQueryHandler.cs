using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentGateway.Domain;

namespace PaymentGateway.Application.Queries.Transaction
{
    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, TransactionViewModel>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionViewModel> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetAsync(request.TransactionId, cancellationToken);

            return new TransactionViewModel
                (transaction.Amount.Value, transaction.Amount.Currency, transaction.CardInfo.MaskedInfo, transaction.Shopper?.Name, transaction.Merchant.Name);
        }
    }
}
