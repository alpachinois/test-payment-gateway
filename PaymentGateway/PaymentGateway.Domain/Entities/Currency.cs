using PaymentGateway.Domain.DomainErrors;

namespace PaymentGateway.Domain.Entities
{
    public class Currency
    {
        public string Code { get; private set; }

        protected Currency()
        {
            
        }

        public Currency(string code)
        {
            SetCode(code);
        }

        private void SetCode(string code)
        {
            if (code.Length != 3)
                throw new InvalidCurrencyCodeException("Currency code should have only 3 characters.");

            Code = code;
        }
    }
}
