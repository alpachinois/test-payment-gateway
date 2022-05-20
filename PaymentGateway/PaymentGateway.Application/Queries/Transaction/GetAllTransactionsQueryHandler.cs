using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentGateway.Domain;

namespace PaymentGateway.Application.Queries.Transaction
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IList<TransactionViewModel>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IList<TransactionViewModel>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetAll(request.MerchantId, cancellationToken);

            var results = 
                transactions.Select(transaction => new TransactionViewModel
                    (transaction.Amount.Value, transaction.Amount.Currency, transaction.CardInfo.MaskedInfo, transaction.Shopper?.Name, transaction.Merchant.Name));

            return results.ToList();
        }
    }
}
