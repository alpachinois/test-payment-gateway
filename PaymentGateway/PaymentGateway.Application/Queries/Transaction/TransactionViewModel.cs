namespace PaymentGateway.Application.Queries.Transaction
{
    public record TransactionViewModel(decimal Amount, string CurrencyCode, string MaskedCardNumber, string ShopperName, string MerchantName);
}
