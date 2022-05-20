using System;
using PaymentGateway.Domain.SeedWork;

namespace PaymentGateway.Domain.Entities
{
    public class Merchant : EntityBase
    {
        public string Name { get; private set; }

        public Merchant(string name)
        {
            Name = name;
        }

        protected Merchant()
        {

        }
    }
}
