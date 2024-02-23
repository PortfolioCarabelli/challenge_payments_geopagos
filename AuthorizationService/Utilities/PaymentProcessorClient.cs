using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConfirmationService.Utilities
{
    public class PaymentProcessorClient
    {
        private readonly HttpClient _httpClient;

        public PaymentProcessorClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<bool> IsPaymentApproved(int AuthorizationId)
        {
            try
            {
               
                var response = await _httpClient.PostAsync($"Confirmation/confirm/{AuthorizationId}", null);


                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                return result == "Authorization confirmed successfully.";
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error al llamar a la API del servicio de confirmación.", ex);
            }
        }
    }
}
