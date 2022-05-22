using PaymentGateway.Application.Commands.TransactionPayment;
using PaymentGateway.Domain.Entities;
using Amount = PaymentGateway.Domain.ValueObjects.Amount;
using Merchant = PaymentGateway.Domain.Entities.Merchant;
using Bank = PaymentGateway.Domain.Entities.Bank;
using CardInfo = PaymentGateway.Domain.Entities.CardInfo;
using Shopper = PaymentGateway.Domain.Entities.Shopper;

namespace PaymentGateway.Application
{
    internal static class Extensions
    {
        internal static Transaction ToDomain(this TransactionPaymentCommand request)
            => new(request.Amount.ToDomain(), request.CardInfo.ToDomain(), request.Merchant.ToDomain(), request.Shopper.ToDomain(), request.Bank.ToDomain());

        internal static Amount ToDomain(this Commands.TransactionPayment.Amount amount) => new (amount.Value, amount.Currency);
        internal static Merchant ToDomain(this Commands.TransactionPayment.Merchant merchant) => new (merchant?.Name);
        internal static Bank ToDomain(this Commands.TransactionPayment.Bank bank) => new (bank?.Name, bank?.ApiUrl);
        internal static CardInfo ToDomain(this Commands.TransactionPayment.CardInfo card) => new(card?.CardNumber, card?.Cvv, card?.HolderName, card.ExpiryMonth, card.ExpiryYear);
        internal static Shopper ToDomain(this Commands.TransactionPayment.Shopper shopper) => new(shopper?.Name);
    }
}
