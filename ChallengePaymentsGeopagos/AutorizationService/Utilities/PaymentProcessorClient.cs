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
                // Realizar la llamada a la API del servicio de confirmación
                //var response = await _httpClient.PostAsync($"confirm", new StringContent(AuthorizationId.ToString()));
                var response = await _httpClient.PostAsync($"confirm/{AuthorizationId}", null);
                //var response = await _httpClient.PostAsync($"confirm/AuthorizationId={AuthorizationId}",null);


                // Verificar si la respuesta fue exitosa
                response.EnsureSuccessStatusCode();

                // Leer el contenido de la respuesta
                var result = await response.Content.ReadAsStringAsync();

                // Analizar la respuesta para determinar si la autorización fue aprobada
                return result == "Authorization confirmed successfully.";
            }
            catch (HttpRequestException ex)
            {
                // Ocurrió un error al llamar a la API del servicio de confirmación
                // Manejar el error según los requisitos de tu aplicación
                throw new Exception("Error al llamar a la API del servicio de confirmación.", ex);
            }
        }
    }
}
