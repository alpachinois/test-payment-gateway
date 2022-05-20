using System;

namespace PaymentGateway.Bank.Mock
{
    public record BankResponse(Guid PaymentId, bool IsSuccess, string Message);
}
