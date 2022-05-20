using System;
using MediatR;

namespace PaymentGateway.Application.Queries.Transaction
{
    public record GetTransactionQuery(Guid TransactionId) : IRequest<TransactionViewModel>;
}
