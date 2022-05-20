using System;
using PaymentGateway.Domain.SeedWork;

namespace PaymentGateway.Domain.DomainErrors
{
    public class InvalidCurrencyCodeException : DomainExceptionBase
    {
        public InvalidCurrencyCodeException(string message) : base(message)
        {
        }

        public InvalidCurrencyCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
