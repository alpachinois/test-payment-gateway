using System;

namespace PaymentGateway.Application.Commands.TransactionPayment
{
    public record TransactionResponse(bool IsSuccess, Guid TransactionId, string Message);
}
