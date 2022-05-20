using MediatR;
using PaymentGateway.Application.Services;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.Application.Commands.BankPayment
{
    public record BankPaymentCommand(Bank Bank, CardInfo CardInfo, Amount Amount) : IRequest<BankResponse>;
}
