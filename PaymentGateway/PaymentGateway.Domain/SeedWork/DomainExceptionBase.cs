using System;

namespace PaymentGateway.Domain.SeedWork
{
    public abstract class DomainExceptionBase : Exception
    {
        protected DomainExceptionBase(string message) : base(message){ }

        protected DomainExceptionBase(string message, Exception innerException) : base(message, innerException) { }
    }
}
