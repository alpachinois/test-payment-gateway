using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.ValueObjects;
using RestSharp;

namespace PaymentGateway.Application.Services
{
    public class BankService : IBankService
    {
        public async Task<BankResponse> ProcessPaymentAsync(CardInfo cardInfo, Bank bank, Amount amount, CancellationToken cancellationToken)
        {
            var client = new RestClient(bank.ApiUrl);
            var request = new RestRequest("BankPayment/transactions");
            request.AddParameter("CardInfo.CardNumber", cardInfo.CardNumber);
            request.AddParameter("CardInfo.Cvv", cardInfo.Cvv);
            request.AddParameter("CardInfo.HolderName", cardInfo.HolderName);
            request.AddParameter("CardInfo.ExpiryMonth", cardInfo.ExpiryMonth);
            request.AddParameter("CardInfo.ExpiryYear", cardInfo.ExpiryYear);
            request.AddParameter("Amount", amount.Value);
            request.AddParameter("CurrencyCode", amount.Currency);
            var response = await client.PostAsync(request);

            if (response.Content != null)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var result = JsonSerializer.Deserialize<BankResponse>(response.Content, options);

                return result;
            }

            throw new JsonException("Cannot deserialize bank response");
        }
    }
}
