using System;
using PaymentGateway.Domain.SeedWork;
using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.Domain.Entities
{
    public class Transaction : AggregateRootBase
    {
        public Amount Amount { get; private set; }
        public CardInfo CardInfo { get; private set; }
        public Merchant Merchant { get; private set; }
        public Shopper Shopper { get; private set; }
        public Bank Bank { get; private set; }

        public Transaction(Amount amount, CardInfo cardInfo, Merchant merchant, Shopper shopper, Bank bank)
        {
            Amount = amount;
            CardInfo = cardInfo;
            Merchant = merchant;
            Shopper = shopper;
            Bank = bank;
        }
    }
}
