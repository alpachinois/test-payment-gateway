using System.Text.RegularExpressions;
using PaymentGateway.Domain.SeedWork;

namespace PaymentGateway.Domain.Entities
{
    public class CardInfo : EntityBase
    {
        private static readonly Regex MaskRegex = new Regex(@"(?<=\d{4}\d{2})\d{2}\d{4}(?=\d{4})|(?<=\d{4}( |-)\d{2})\d{2}\1\d{4}(?=\1\d{4})");
        public string CardNumber { get; private set; }
        public string Cvv { get; private set; }
        public string HolderName { get; private set; }
        public int ExpiryMonth { get; private set; }
        public int ExpiryYear { get; private set; }
        public CardInfo(string cardNumber, string cvv, string holderName, int expiryMonth, int expiryYear)
        {
            CardNumber = cardNumber;
            Cvv = cvv;
            HolderName = holderName;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
        }

        protected CardInfo()
        {

        }

        public string MaskedInfo => MaskRegex.Replace(CardNumber, (m) => new string('*', m.Length));
    }
}
