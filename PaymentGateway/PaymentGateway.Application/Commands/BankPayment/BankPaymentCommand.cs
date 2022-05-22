using MediatR;
using PaymentGateway.Application.Commands.TransactionPayment;
using PaymentGateway.Application.Services;

namespace PaymentGateway.Application.Commands.BankPayment
{
    public record BankPaymentCommand(Bank Bank, CardInfo CardInfo, Amount Amount) : IRequest<BankResponse>;
}
