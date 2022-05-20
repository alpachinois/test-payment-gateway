using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using PaymentGateway.Application.Queries.Transaction;
using Moq;
using PaymentGateway.Domain;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.ValueObjects;

namespace PaymentGateway.Application.Tests
{
    public class TransactionQueriesTests
    {
        [Fact]
        public async Task Given_TransactionId_When_AskForTransaction_Then_ReturnResult()
        {
            //GIVEN
            var transactionId = Guid.NewGuid();

            var cardInfo = new CardInfo("1234-5678-9123-7897", "123", "test", 12, 25);
            var amount = new Amount(30m, "EUR");
            var bank = new Bank("fakeBank", "http://localhost/fake");
            var merchant = new Merchant("test");
            var shopper = new Shopper("test");
            var repoMock = new Mock<ITransactionRepository>();
            repoMock.Setup(x => x.GetAsync(transactionId, CancellationToken.None))
                .ReturnsAsync(new Transaction(amount, cardInfo, merchant, shopper, bank))
                .Verifiable();

            //WHEN
            var query = new GetTransactionQuery(transactionId);
            var queryHandler = new GetTransactionQueryHandler(repoMock.Object);

            //THEN
            var sut = await queryHandler.Handle(query, CancellationToken.None);
            sut.Should().NotBeNull();
            sut.Amount.Should().Be(amount.Value);
            sut.CurrencyCode.Should().BeEquivalentTo(amount.Currency);
            sut.ShopperName.Should().BeEquivalentTo(shopper.Name);
            sut.MerchantName.Should().BeEquivalentTo(merchant.Name);
            sut.MaskedCardNumber.Should().BeEquivalentTo(cardInfo.MaskedInfo);

            repoMock.Verify(x => x.GetAsync(transactionId, CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Given_MerchantId_When_AskForTransactions_Then_ReturnAllResult()
        {
            //GIVEN
            var merchantId = Guid.NewGuid();

            var cardInfo = new CardInfo("1234-5678-9123-7897", "123", "test", 12, 25);
            var amount = new Amount(30m, "EUR");
            var bank = new Bank("fakeBank", "http://localhost/fake");
            var merchant = new Merchant("test");
            var shopper = new Shopper("test");
            var repoMock = new Mock<ITransactionRepository>();
            repoMock.Setup(x => x.GetAll(merchantId, CancellationToken.None))
                .ReturnsAsync(new List<Transaction> { new (amount, cardInfo, merchant, shopper, bank) })
                .Verifiable();

            //WHEN
            var query = new GetAllTransactionsQuery(merchantId);
            var queryHandler = new GetAllTransactionsQueryHandler(repoMock.Object);

            //THEN
            var sut = await queryHandler.Handle(query, CancellationToken.None);
            sut.Should().NotBeNull();
            sut.Count.Should().Be(1);

            repoMock.Verify(x => x.GetAll(merchantId, CancellationToken.None), Times.Once);
        }
    }
}
