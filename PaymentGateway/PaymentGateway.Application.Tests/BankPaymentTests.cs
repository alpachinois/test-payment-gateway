using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using PaymentGateway.Application.Commands.BankPayment;
using Xunit;
using Moq;
using PaymentGateway.Application.Commands.TransactionPayment;
using PaymentGateway.Application.Services;

namespace PaymentGateway.Application.Tests
{
    public class BankPaymentTests
    {
        [Fact]
        public async Task Given_PaymentInformation_When_ContactForBankPayment_Then_ReturnResult()
        {
            //GIVEN
            var bankInfo = new Bank("test", "http://localhost/fake");
            var cardInfo = new CardInfo("1234-5678-9123-7897", "123", "test", 12, 25);

            var bankMock = new Mock<IBankService>();
            bankMock.Setup(x => x.ProcessPaymentAsync(cardInfo, bankInfo, new Amount(200m, "EUR"), CancellationToken.None))
                .ReturnsAsync(new BankResponse(Guid.NewGuid(), true, "OK"))
                .Verifiable();

            //WHEN
            var command = new BankPaymentCommand(bankInfo, cardInfo, new Amount(200m, "EUR"));
            var commandHandler = new BankPaymentCommandHandler(bankMock.Object);

            //THEN
            var sut = await commandHandler.Handle(command, CancellationToken.None);
            
            sut.Should().NotBeNull();
            bankMock.Verify(x => x.ProcessPaymentAsync(cardInfo, bankInfo, new Amount(200m, "EUR"), CancellationToken.None), Times.Once);
        }
    }
}
