using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using MediatR;
using Moq;
using PaymentGateway.Application.Commands.BankPayment;
using PaymentGateway.Application.Commands.TransactionPayment;
using PaymentGateway.Application.Services;

namespace PaymentGateway.Application.Tests
{
    public class ProcessPaymentTests
    {
        [Fact]
        public async Task  Given_Merchant_When_ProcessPaymentAndSuccess_Then_ReturnSuccessPaymentResponse()
        {
            var command = new TransactionPaymentCommand
            {
                Merchant = new Merchant("test merchant"),
                CardInfo = new CardInfo("1234-5678-9123-7897", "123", "test", 12, 25),
                Amount = new Amount(30m, "EUR"),
                Bank = new Bank("fakeBank", "http://localhost/fake")
            };
            
            var mediatorMoq = new Mock<IMediator>();
            mediatorMoq.Setup(x => x.Send(It.IsAny<BankPaymentCommand>(), CancellationToken.None))
                .ReturnsAsync(new BankResponse(Guid.NewGuid(), true, "OK"))
                .Verifiable();
            var cardInfo = new Domain.Entities.CardInfo("1234-5678-9123-7897", "123", "test", 12, 25);
            var amount = new Domain.ValueObjects.Amount(30m, "EUR");
            var bank = new Domain.Entities.Bank("fakeBank", "http://localhost/fake");
            var merchant = new Domain.Entities.Merchant("test");
            var shopper = new Domain.Entities.Shopper("test");
            var transaction = new Domain.Entities.Transaction(amount, cardInfo, merchant, shopper, bank);
            var repoMock = new Mock<Domain.ITransactionRepository>();
            repoMock.Setup(x => x.CreateAsync(It.IsAny<Domain.Entities.Transaction>(), CancellationToken.None))
                .ReturnsAsync(transaction)
                .Verifiable();

            var commandHandler = new TransactionPaymentCommandHandler(mediatorMoq.Object, repoMock.Object);

            var sut = await commandHandler.Handle(command, CancellationToken.None);

            sut.Should().NotBeNull();
            sut.IsSuccess.Should().BeTrue();
            sut.TransactionId.Should().NotBeEmpty();
            mediatorMoq.Verify(x => x.Send(It.IsAny<BankPaymentCommand>(), CancellationToken.None), Times.Once);
            repoMock.Verify(x => x.CreateAsync(It.IsAny<Domain.Entities.Transaction>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Given_Merchant_When_ProcessPaymentAndFailed_Then_ReturnFailedPaymentResponse()
        {
            var command = new TransactionPaymentCommand
            {
                Merchant = new Merchant("test merchant"),
                CardInfo = new CardInfo("1234-5678-9123-7897", "123", "test", 12, 25),
                Amount = new Amount(30m, "EUR"),
                Bank = new Bank("fakeBank", "http://localhost/fake")
            };

            var mediatorMoq = new Mock<IMediator>();
            mediatorMoq.Setup(x => x.Send(It.IsAny<BankPaymentCommand>(), CancellationToken.None))
                .ReturnsAsync(new BankResponse(Guid.NewGuid(), false, "KO"))
                .Verifiable();

            var cardInfo = new Domain.Entities.CardInfo("1234-5678-9123-7897", "123", "test", 12, 25);
            var amount = new Domain.ValueObjects.Amount(30m, "EUR");
            var bank = new Domain.Entities.Bank("fakeBank", "http://localhost/fake");
            var merchant = new Domain.Entities.Merchant("test");
            var shopper = new Domain.Entities.Shopper("test");
            var transaction = new Domain.Entities.Transaction(amount, cardInfo, merchant, shopper, bank);
            var repoMock = new Mock<Domain.ITransactionRepository>();
            repoMock.Setup(x => x.CreateAsync(It.IsAny<Domain.Entities.Transaction>(), CancellationToken.None))
                .ReturnsAsync(transaction)
                .Verifiable();

            var commandHandler = new TransactionPaymentCommandHandler(mediatorMoq.Object, repoMock.Object);

            var sut = await commandHandler.Handle(command, CancellationToken.None);

            sut.Should().NotBeNull();
            sut.IsSuccess.Should().BeFalse();
            sut.TransactionId.Should().BeEmpty();
            mediatorMoq.Verify(x => x.Send(It.IsAny<BankPaymentCommand>(), CancellationToken.None), Times.Once);
            repoMock.Verify(x => x.CreateAsync(It.IsAny<Domain.Entities.Transaction>(), CancellationToken.None), Times.Never);
        }
    }
}
