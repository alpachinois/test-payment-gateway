using System;
using PaymentGateway.Domain.Entities;
using Xunit;
using FluentAssertions;
using PaymentGateway.Domain.DomainErrors;

namespace PaymentGateway.Domain.Tests
{
    public class CurrencyTests
    {
        [Fact]
        public void Given_CurrencyCode_When_LengthIsNotEqualThreeCharacters_Then_ThrowError()
        {
            //GIVEN
            Func<Currency> currencyCode;

            //WHEN
            currencyCode = () => new Currency("Bad_Code");

            //THEN
            currencyCode.Should().ThrowExactly<InvalidCurrencyCodeException>();
        }
    }
}
