namespace PaymentGateway.Bank.Mock
{
    public record CardInfo(string CardNumber, string Cvv, string HolderName, int ExpiryMonth, int ExpiryYear);
}
