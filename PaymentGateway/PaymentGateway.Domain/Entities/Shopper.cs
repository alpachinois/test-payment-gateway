using PaymentGateway.Domain.SeedWork;

namespace PaymentGateway.Domain.Entities
{
    public class Shopper : EntityBase
    {
        protected Shopper()
        {

        }

        public Shopper(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
