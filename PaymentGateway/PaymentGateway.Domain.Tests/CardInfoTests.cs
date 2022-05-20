using System;
using PaymentGateway.Domain.Entities;
using Xunit;
using FluentAssertions;

namespace PaymentGateway.Domain.Tests
{
    public class CardInfoTests
    {
        [Theory]
        [InlineData("4929 0000 1111 2222", "4929 00******* 2222")]
        [InlineData("4929-0000-1111-2222", "4929-00*******-2222")]
        public void Given_CardNumber_When_GetMaskedInfo_Then_ReturnMaskedCardNumber(string cardNumber, string expectedResult)
        {
            //GIVEN
            var cardInfo = new CardInfo(cardNumber, string.Empty, string.Empty, 12, 23);

            //WHEN
            var sut = cardInfo.MaskedInfo;

            //THEN
            sut.Should().Be(expectedResult);
        }
    }
}
