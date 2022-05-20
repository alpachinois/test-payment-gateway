using System;

namespace PaymentGateway.Application.Services
{
    public record BankResponse(Guid PaymentId, bool IsSuccess, string Message);
}
