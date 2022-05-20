namespace PaymentGateway.Domain.ValueObjects
{
    public record Amount(decimal Value, string Currency)
    {
        public decimal ConvertToAnotherCurrency(decimal rate) => Value * rate;
    }
}
