namespace PaymentGateway.Bank.Mock
{
    public record PaymentInfo(CardInfo CardInfo, decimal Amount, string CurrencyCode);
}
