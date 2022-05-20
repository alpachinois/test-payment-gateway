using System;
using System.Collections;
using System.Collections.Generic;
using MediatR;

namespace PaymentGateway.Application.Queries.Transaction
{
    public record GetAllTransactionsQuery(Guid MerchantId) : IRequest<IList<TransactionViewModel>>;
}
