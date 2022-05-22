using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace PaymentGateway.Application.Commands.TransactionPayment
{
    public record TransactionPaymentCommand : IRequest<TransactionResponse>
    {
        [Required]
        public Merchant Merchant { get; init; }
        [Required]
        public Amount Amount { get; init; }
        [Required]
        public Bank Bank { get; init; }
        public CardInfo CardInfo { get; init; }
        public Guid CardId { get; init; }
        public Shopper Shopper { get; set; }
    }

    public record Merchant(string Name);
    public record Shopper(string Name);
    public record Amount(decimal Value, string Currency);
    public record Bank(string Name, string ApiUrl);
    public record CardInfo(string CardNumber, string Cvv, string HolderName, int ExpiryMonth, int ExpiryYear);
}
