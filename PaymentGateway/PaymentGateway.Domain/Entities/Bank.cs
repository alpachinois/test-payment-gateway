using PaymentGateway.Domain.SeedWork;

namespace PaymentGateway.Domain.Entities
{
    public class Bank : EntityBase
    {
        protected Bank()
        {
        }

        public Bank(string name, string apiUrl)
        {
            Name = name;
            ApiUrl = apiUrl;
        }

        public string Name { get; private set; }

        public string ApiUrl { get; private set; }
    }
}
