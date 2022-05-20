using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.ValueObjects;

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
}
